/*
Created		23.09.2008
Modified		20.01.2009
Project		
Model			
Company		
Author		
Version		
Database		PostgreSQL 8.1 
*/



/* Drop Referential Integrity Triggers */





/* Drop User-Defined Triggers */



/* Drop Trigger Functions */



/* Drop Domains */



/* Drop Procedures */
Drop FUNCTION add_bill_money (bill_id_param integer);
Drop FUNCTION calculate_call_cost_function (call_id_param integer);



/* Drop Rules */
Drop RULE bills_on_insert_rule ON bills Cascade;
Drop RULE calls_on_insert_rule ON calls Cascade;
Drop RULE abonents_on_insert_rule ON abonents Cascade;
Drop RULE corporate_abonents_on_insert_rule ON corporate_abonents Cascade;
Drop RULE private_abonents_on_insert_rule ON private_abonents Cascade;



/* Drop Views */



/* Drop Indexes */



/* Drop Tables */
Drop table "users" Cascade;
Drop table "bills" Cascade;
Drop table "calls" Cascade;
Drop table "prices" Cascade;
Drop table "rates" Cascade;
Drop table "numbers" Cascade;
Drop table "corporate_abonents" Cascade;
Drop table "private_abonents" Cascade;
Drop table "abonents" Cascade;



/* Drop Sequences */



/* Create Domains */



/* Create Tables */


Create table "abonents"
(
	"id" Serial NOT NULL,
	"address" Varchar(100),
	"phone" Varchar(13),
	"creation_time" Timestamp,
	"balance" Numeric(30,3) Default 0,
	"last_calc_date" Timestamp,
	"mail_address" Varchar(30),
	"dissolved" Boolean NOT NULL Default false,
 primary key ("id")
) Without Oids;


Create table "private_abonents"
(
	"surname" Varchar(30) NOT NULL,
	"name" Varchar(30) NOT NULL,
	"patronymic" Varchar(30) NOT NULL,
	"passport_series" Varchar(10) NOT NULL UNIQUE,
	"passport_date" Timestamp,
	"passport_department" Varchar(100),
	"birth_date" Timestamp
) Inherits ("abonents")
 Without Oids;


Create table "corporate_abonents"
(
	"corporate_name" Varchar(100) NOT NULL,
	"inn" Varchar(20) NOT NULL UNIQUE
) Inherits ("abonents")
 Without Oids;


Create table "numbers"
(
	"id" Serial NOT NULL,
	"rate_id" Integer NOT NULL,
	"number" Varchar(10) NOT NULL,
	"abonent_id" Integer NOT NULL,
 primary key ("id")
) Without Oids;


Create table "rates"
(
	"id" Serial NOT NULL,
	"name" Varchar(100) NOT NULL,
 primary key ("id")
) Without Oids;


Create table "prices"
(
	"id" Serial NOT NULL,
	"rate_id" Integer NOT NULL,
	"cost_per_minute" Numeric(30,3) NOT NULL,
	"mask" Varchar(10),
 primary key ("id")
) Without Oids;


Create table "calls"
(
	"id" Serial NOT NULL,
	"calling_number" Varchar(20) NOT NULL,
	"creation_time" Timestamp NOT NULL,
	"duration" Integer NOT NULL,
	"number_id" Integer NOT NULL,
	"cost" Numeric(30,3),
 primary key ("id")
) Without Oids;


Create table "bills"
(
	"id" Serial NOT NULL,
	"number_id" Integer NOT NULL,
	"money" Numeric(30,3) NOT NULL,
	"creation_time" Timestamp,
 primary key ("id")
) Without Oids;


Create table "users"
(
	"id" Serial NOT NULL,
	"login" Varchar(20) NOT NULL,
	"pass" Varchar(20) NOT NULL,
	"rights" Integer,
 primary key ("id")
) Without Oids;



/* Create Tab 'Others' for Selected Tables */


/* Create Alternate Keys */
Alter Table "prices" add Constraint "mask_unique_key" UNIQUE ("rate_id","mask");



/* Create Indexes */



/* Create Foreign Keys */

Alter table "calls" add  foreign key ("number_id") references "numbers" ("id") on update cascade on delete cascade;

Alter table "bills" add  foreign key ("number_id") references "numbers" ("id") on update cascade on delete cascade;

Alter table "numbers" add  foreign key ("rate_id") references "rates" ("id") on update cascade on delete restrict;

Alter table "prices" add  foreign key ("rate_id") references "rates" ("id") on update cascade on delete cascade;



/* Create Procedures */
CREATE OR REPLACE FUNCTION add_bill_money(bill_id_param integer)
  RETURNS void AS
$BODY$UPDATE abonents 
SET balance = (abonents.balance + (SELECT money FROM bills WHERE id = $1))
  WHERE abonents.id = (SELECT numbers.abonent_id
    FROM numbers, bills
    WHERE numbers.id = bills.number_id AND bills.id = $1);$BODY$
  LANGUAGE 'sql' VOLATILE
  COST 100;
ALTER FUNCTION add_bill_money(integer) OWNER TO postgres;
COMMENT ON FUNCTION add_bill_money(integer) IS 'adds money of the bill to abonents balance';

CREATE OR REPLACE FUNCTION calculate_call_cost_function(call_id_param integer)
  RETURNS void AS
$BODY$UPDATE calls SET cost = (calls.duration / 60.0) * (
         SELECT prices.cost_per_minute FROM prices, rates, numbers, calls
         WHERE calls.id = $1 AND numbers.id = calls.number_id AND rates.id = numbers.rate_id
         AND prices.rate_id = rates.id AND calls.calling_number like (prices.mask ||'%'))
WHERE calls.id = $1;$BODY$
  LANGUAGE 'sql' VOLATILE
  COST 100;
ALTER FUNCTION calculate_call_cost_function(integer) OWNER TO postgres;






/* Create Views */



/* Create Rules */
/*CREATE OR REPLACE RULE bills_on_insert_rule AS
    ON INSERT TO bills DO  SELECT add_bill_money(new.id) AS add_bill_money;
*/

/*CREATE OR REPLACE RULE calls_on_insert_rule AS
    ON INSERT TO calls DO  SELECT calculate_call_cost_function(new.id) AS calculate_call_cost_function;
*/

/*CREATE OR REPLACE RULE abonents_on_insert_rule AS
    ON INSERT TO abonents DO  UPDATE abonents SET balance = 0::numeric
  WHERE abonents.id = new.id;
*/

/*CREATE OR REPLACE RULE corporate_abonents_on_insert_rule AS
    ON INSERT TO corporate_abonents DO  UPDATE abonents SET balance = 0::numeric
  WHERE abonents.id = new.id;
*/

/*CREATE OR REPLACE RULE private_abonents_on_insert_rule AS
    ON INSERT TO private_abonents DO  UPDATE abonents SET balance = 0::numeric
  WHERE abonents.id = new.id;
*/




/* Create Referential Integrity Triggers */





/* Create User-Defined Triggers */



/* Create Roles */



/* Add Roles To Roles */



/* Create Role Permissions */
/* Role permissions on tables */

/* Role permissions on views */

/* Role permissions on procedures */


Alter table "private_abonents" add  primary key ("id");
Alter table "corporate_abonents" add  primary key ("id");





/*
Created		23.09.2008
Modified		15.12.2008
Project		
Model			
Company		
Author		
Version		
Database		PostgreSQL 8.1 
*/



/* Drop Referential Integrity Triggers */





/* Drop User-Defined Triggers */



/* Drop Domains */



/* Drop Procedures */



/* Drop Views */



/* Drop Indexes */



/* Drop Tables */
Drop table "private_abonents" Restrict;
Drop table "corporate_abonents" Restrict;
Drop table "bills" Restrict;
Drop table "numbers" Restrict;
Drop table "users" Restrict;
Drop table "calls" Restrict;
Drop table "rates" Restrict;
Drop table "prices" Restrict;
Drop table "abonents" Restrict;



/* Create Domains */



/* Create Tables */


Create table "abonents"
(
	"id" Serial NOT NULL,
	"address" Varchar(100),
	"phone" Varchar(13),
	"reg_time" Timestamp,
	"balance" Numeric(30,6),
	"last_pay_date" Timestamp,
	"mail_address" Varchar(30),
 primary key ("id")
) Without Oids;


Create table "prices"
(
	"id" Serial NOT NULL,
	"rate_id" Integer NOT NULL,
	"cost_per_minute" Numeric(30,6) NOT NULL,
	"mask" Varchar(10),
	"idx" Integer,
 primary key ("id")
) Without Oids;


Create table "rates"
(
	"id" Serial NOT NULL,
	"name" Varchar(100) NOT NULL,
 primary key ("id")
) Without Oids;


Create table "calls"
(
	"id" Serial NOT NULL,
	"calling_number" Varchar(20) NOT NULL,
	"start_time" Timestamp NOT NULL,
	"duration" Integer NOT NULL,
	"number_id" Integer NOT NULL,
	"cost" Numeric(30,6),
	"idx" Integer,
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


Create table "numbers"
(
	"id" Serial NOT NULL,
	"rate_id" Integer NOT NULL,
	"number" Varchar(10) NOT NULL,
	"idx" Integer,
 primary key ("id")
) Without Oids;


Create table "bills"
(
	"id" Serial NOT NULL,
	"number_id" Integer NOT NULL,
	"money" Numeric(30,6) NOT NULL,
	"bill_date" Timestamp,
	"idx" Integer,
 primary key ("id")
) Without Oids;


Create table "corporate_abonents"
(
	"corporate_name" Varchar(100) NOT NULL
) Inherits ("abonents")
 Without Oids;


Create table "private_abonents"
(
	"surname" Varchar(30) NOT NULL,
	"name" Varchar(30) NOT NULL,
	"patronymic" Varchar(30) NOT NULL,
	"passport_series" Varchar(10),
	"passport_date" Timestamp,
	"passport_department" Varchar(100),
	"birth_date" Timestamp
) Inherits ("abonents")
 Without Oids;



/* Create Tab 'Others' for Selected Tables */


/* Create Alternate Keys */



/* Create Indexes */



/* Create Foreign Keys */

Alter table "numbers" add  foreign key ("rate_id") references "rates" ("id") on update cascade on delete cascade;

Alter table "prices" add  foreign key ("rate_id") references "rates" ("id") on update cascade on delete cascade;

Alter table "calls" add  foreign key ("number_id") references "numbers" ("id") on update cascade on delete cascade;

Alter table "bills" add  foreign key ("number_id") references "numbers" ("id") on update cascade on delete cascade;



/* Create Procedures */



/* Create Views */



/* Create Referential Integrity Triggers */





/* Create User-Defined Triggers */



/* Create Roles */



/* Add Roles To Roles */



/* Create Role Permissions */
/* Role permissions on tables */

/* Role permissions on views */

/* Role permissions on procedures */







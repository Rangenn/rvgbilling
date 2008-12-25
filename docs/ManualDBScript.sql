Alter table "corporate_abonents" add  primary key ("id")
Alter table "private_abonents" add  primary key ("id")





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




CREATE OR REPLACE RULE bills_on_insert_rule AS
    ON INSERT TO bills DO  SELECT add_bill_money(new.id) AS add_bill_money;


CREATE OR REPLACE RULE calls_on_insert_rule AS
    ON INSERT TO calls DO  SELECT calculate_call_cost_function(new.id) AS calculate_call_cost_function;



CREATE OR REPLACE RULE abonents_on_insert_rule AS
    ON INSERT TO abonents DO  UPDATE abonents SET balance = 0::numeric
  WHERE abonents.id = new.id;

CREATE OR REPLACE RULE corporate_abonents_on_insert_rule AS
    ON INSERT TO corporate_abonents DO  UPDATE abonents SET balance = 0::numeric
  WHERE abonents.id = new.id;

CREATE OR REPLACE RULE private_abonents_on_insert_rule AS
    ON INSERT TO private_abonents DO  UPDATE abonents SET balance = 0::numeric
  WHERE abonents.id = new.id;

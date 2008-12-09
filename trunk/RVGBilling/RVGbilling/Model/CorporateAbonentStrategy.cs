using System;
using System.Collections.Generic;
using Npgsql;
using System.Text;
using System.Data;
using NpgsqlTypes;


namespace RVGbilling.Model
{
    class CorporateAbonentStrategy : AbonentStrategy
    {
        protected override string InsertQueryString
        {
            get
            {
                return "INSERT INTO abonents (address, phone, mail_address, reg_time, last_pay_date, balance, corporate_name) "
                  + "VALUES (:1,:2,:3,:4,:5,:6, :cname)";
            }
        }
        protected override string UpdateQueryString
        {
            get
            {
                return "UPDATE abonents SET address = :1, phone = :2, mail_address = :3, reg_time = :4, last_pay_date = :5, balance = :6, corporate_name = :cname "
                    + "WHERE abonent_id = :7";
            }
        }
        protected override string DeleteQueryString
        {
            get
            {
                return "DELETE FROM corporate_abonents "
                    + "WHERE abonent_id = :1";
            }
        }

        protected override void formCommandVals(Abonent buf, NpgsqlCommand command)
        {
            CorporateAbonent cbuf = (CorporateAbonent)buf;
            base.formCommandVals(buf, command);
            command.Parameters["cname"].Value = cbuf.CorporationName;
        }

        protected override void formCommandParams(NpgsqlCommand command)
        {
            base.formCommandParams(command);
            command.Parameters.Add(new NpgsqlParameter("cname", NpgsqlDbType.Varchar));
        } 
    }
}

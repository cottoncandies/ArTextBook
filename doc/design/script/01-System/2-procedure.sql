create function record_cmrv_chg__fn()
RETURNS TRIGGER
AS $FUNC$
BEGIN
    if (TG_OP='UPDATE') THEN 
        NEW.ts_update = CURRENT_TIMESTAMP;
        NEW.nt_r_ver = OLD.nt_r_ver+1;  
    ELSIF (TG_OP='INSERT') then
        NEW.ts_create = CURRENT_TIMESTAMP;
        NEW.ts_update = CURRENT_TIMESTAMP;
        NEW.nt_r_ver = 1;  
    END if;
    return NEW;
END;
$FUNC$  LANGUAGE plpgsql;
 
create trigger sys_user__record_cmrv__tr BEFORE INSERT OR UPDATE ON sys_user_t
FOR EACH ROW
EXECUTE PROCEDURE record_cmrv_chg__fn();

create trigger sys_config__record_cmrv__tr BEFORE INSERT OR UPDATE ON sys_config_t
FOR EACH ROW
EXECUTE PROCEDURE record_cmrv_chg__fn();

create trigger sys_role__record_cmrv__tr BEFORE INSERT OR UPDATE ON sys_role_t
FOR EACH ROW
EXECUTE PROCEDURE record_cmrv_chg__fn();

create trigger sys_user_qa__record_cmrv__tr BEFORE INSERT OR UPDATE ON sys_user_qa_t
FOR EACH ROW
EXECUTE PROCEDURE record_cmrv_chg__fn();









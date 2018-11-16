
create trigger atb_grade__record_cmrv__tr BEFORE INSERT OR UPDATE ON atb_grade_t
FOR EACH ROW
EXECUTE PROCEDURE record_cmrv_chg__fn();

create trigger atb_edition__record_cmrv__tr BEFORE INSERT OR UPDATE ON atb_edition_t
FOR EACH ROW
EXECUTE PROCEDURE record_cmrv_chg__fn();

create trigger atb_subject__record_cmrv__tr BEFORE INSERT OR UPDATE ON atb_subject_t
FOR EACH ROW
EXECUTE PROCEDURE record_cmrv_chg__fn();

create trigger atb_publish__record_cmrv__tr BEFORE INSERT OR UPDATE ON atb_publish_t
FOR EACH ROW
EXECUTE PROCEDURE record_cmrv_chg__fn();

create trigger atb_textbook__record_cmrv__tr BEFORE INSERT OR UPDATE ON atb_textbook_t
FOR EACH ROW
EXECUTE PROCEDURE record_cmrv_chg__fn();

create trigger atb_page__record_cmrv__tr BEFORE INSERT OR UPDATE ON atb_page_t
FOR EACH ROW
EXECUTE PROCEDURE record_cmrv_chg__fn();

create trigger atb_res__record_cmrv__tr BEFORE INSERT OR UPDATE ON atb_res_t
FOR EACH ROW
EXECUTE PROCEDURE record_cmrv_chg__fn();

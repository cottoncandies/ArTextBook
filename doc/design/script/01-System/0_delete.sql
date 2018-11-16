DROP SEQUENCE IF EXISTS sys_user_qa__id__seq;
DROP SEQUENCE IF EXISTS sys_user_role__id__seq;
DROP SEQUENCE IF EXISTS sys_role_mod__id__seq;
DROP SEQUENCE IF EXISTS sys_role__id__seq;
DROP SEQUENCE IF EXISTS sys_module__id__seq;
DROP SEQUENCE IF EXISTS sys_log__id__seq;
DROP SEQUENCE IF EXISTS sys_user__id__seq;
DROP SEQUENCE IF EXISTS sys_ucverify__id__seq;

DROP TABLE IF EXISTS sys_user_qa_t CASCADE;
DROP TABLE IF EXISTS sys_user_role__id__seq CASCADE;
DROP TABLE IF EXISTS sys_role_mod_t CASCADE;
DROP TABLE IF EXISTS sys_role_t CASCADE;
DROP TABLE IF EXISTS sys_module_t CASCADE;
DROP TABLE IF EXISTS sys_log_t CASCADE;
DROP TABLE IF EXISTS sys_config_t CASCADE;
DROP TABLE IF EXISTS sys_user_t CASCADE;
DROP TABLE IF EXISTS sys_ucverify_t CASCADE;

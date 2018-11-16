DROP TABLE IF EXISTS "atb_edit_log_t" CASCADE;
DROP TABLE IF EXISTS "atb_edition_t" CASCADE;
DROP TABLE IF EXISTS "atb_grade_t" CASCADE;
DROP TABLE IF EXISTS "atb_page_t" CASCADE;
DROP TABLE IF EXISTS "atb_publish_t" CASCADE;
DROP TABLE IF EXISTS "atb_res_t" CASCADE;
DROP TABLE IF EXISTS "atb_subject_t" CASCADE;
DROP TABLE IF EXISTS "atb_textbook_t" CASCADE;

DROP SEQUENCE IF EXISTS "atb_edit_log__id__seq";
DROP SEQUENCE IF EXISTS "atb_edition__id__seq";
DROP SEQUENCE IF EXISTS "atb_grade__id__seq";
DROP SEQUENCE IF EXISTS "atb_page__id__seq";
DROP SEQUENCE IF EXISTS "atb_publish__id__seq";
DROP SEQUENCE IF EXISTS "atb_res__id__seq";
DROP SEQUENCE IF EXISTS "atb_subject__id__seq";
DROP SEQUENCE IF EXISTS "atb_textbook__id__seq";

CREATE SEQUENCE "atb_edit_log__id__seq" INCREMENT 1 START 1;
CREATE SEQUENCE "atb_edition__id__seq" INCREMENT 1 START 1;
CREATE SEQUENCE "atb_grade__id__seq" INCREMENT 1 START 1;
CREATE SEQUENCE "atb_page__id__seq" INCREMENT 1 START 1;
CREATE SEQUENCE "atb_publish__id__seq" INCREMENT 1 START 1;
CREATE SEQUENCE "atb_res__id__seq" INCREMENT 1 START 1;
CREATE SEQUENCE "atb_subject__id__seq" INCREMENT 1 START 1;
CREATE SEQUENCE "atb_textbook__id__seq" INCREMENT 1 START 1;

CREATE TABLE "atb_grade_t"
(
	"ng_id" bigint NOT NULL DEFAULT nextval(('"atb_grade__id__seq"'::text)::regclass),
	"sz_caption" varchar(127)	 NOT NULL,
	"nt_section" integer NOT NULL DEFAULT 1,
	"sz_insti" varchar(15)	 NOT NULL DEFAULT '633',
	"ng_ctor_id" bigint NOT NULL,
	"ng_uper_id" bigint NOT NULL,
	"ts_create" timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
	"ts_update" timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
	"nt_r_state" integer NOT NULL DEFAULT 1,
	"nt_r_ver" integer NOT NULL DEFAULT 1
);
ALTER TABLE "atb_grade_t" ADD CONSTRAINT "atb_grade__pk"
	PRIMARY KEY ("ng_id");

CREATE TABLE "atb_edition_t"
(
	"ng_id" bigint NOT NULL DEFAULT nextval(('"atb_edition__id__seq"'::text)::regclass),
	"sz_caption" varchar(127)	 NOT NULL,
	"ng_ctor_id" bigint NOT NULL,
	"ng_uper_id" bigint NOT NULL,
	"ts_create" timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
	"ts_update" timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
	"nt_r_state" integer NOT NULL DEFAULT 1,
	"nt_r_ver" integer NOT NULL DEFAULT 1
);
ALTER TABLE "atb_edition_t" ADD CONSTRAINT "atb_edition__pk"
	PRIMARY KEY ("ng_id");

CREATE TABLE "atb_subject_t"
(
	"ng_id" bigint NOT NULL DEFAULT nextval(('"atb_subject__id__seq"'::text)::regclass),
	"sz_caption" varchar(127)	 NOT NULL,
	"ng_ctor_id" bigint NOT NULL,
	"ng_uper_id" bigint NOT NULL,
	"ts_create" timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
	"ts_update" timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
	"nt_r_state" integer NOT NULL DEFAULT 1,
	"nt_r_ver" integer NOT NULL DEFAULT 1
);
ALTER TABLE "atb_subject_t" ADD CONSTRAINT "atb_subject__pk"
	PRIMARY KEY ("ng_id");

CREATE TABLE "atb_publish_t"
(
	"ng_id" bigint NOT NULL DEFAULT nextval(('"atb_publish__id__seq"'::text)::regclass),
	"sz_caption" varchar(127)	 NOT NULL,
	"ng_ctor_id" bigint NOT NULL,
	"ng_uper_id" bigint NOT NULL,
	"ts_create" timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
	"ts_update" timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
	"nt_r_state" integer NOT NULL DEFAULT 1,
	"nt_r_ver" integer NOT NULL DEFAULT 1
);
ALTER TABLE "atb_publish_t" ADD CONSTRAINT "atb_publish__pk"
	PRIMARY KEY ("ng_id");


CREATE TABLE "atb_textbook_t"
(
	"ng_id" bigint NOT NULL DEFAULT nextval(('"atb_textbook__id__seq"'::text)::regclass),
	"sz_oid" varchar(63)	 NOT NULL,
	"sz_caption" varchar(127)	 NOT NULL,
	"sz_cover" varchar(255)	 NOT NULL DEFAULT '00000.jpg',
	"ng_grade_id" bigint NOT NULL,
	"ng_edition_id" bigint NOT NULL,
	"ng_subject_id" bigint NOT NULL,
	"ng_publish_id" bigint NOT NULL,
	"sz_src_store" varchar(255)	,
	"sz_src_md5" varchar(63)	,
	"ng_src_size" bigint NOT NULL DEFAULT 0,
	"sz_dst_store" varchar(255)	,
	"sz_dst_md5" varchar(63)	,
	"sz_img_path" varchar(255)	 NOT NULL,
	"sz_res_path" varchar(255)	 NOT NULL,
	"ng_dst_size" bigint NOT NULL DEFAULT 0,
	"nt_state" integer NOT NULL DEFAULT 0,
	"ng_editor_id" bigint,
	"ng_ctor_id" bigint NOT NULL,
	"ng_uper_id" bigint NOT NULL,
	"ts_create" timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
	"ts_update" timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
	"nt_r_state" integer NOT NULL DEFAULT 1,
	"nt_r_ver" integer NOT NULL DEFAULT 1
);
ALTER TABLE "atb_textbook_t" ADD CONSTRAINT "atb_textbook__pk"
	PRIMARY KEY ("ng_id");
CREATE INDEX "atb_textbook__oid__pk" ON "atb_textbook_t" ("sz_oid" ASC);


CREATE TABLE "atb_edit_log_t"
(
	"ng_id" bigint NOT NULL DEFAULT nextval(('"atb_edit_log__id__seq"'::text)::regclass),
	"ng_book_id" bigint NOT NULL,
	"ng_user_id" bigint NOT NULL,
	"ts_begin" timestamp,
	"ts_end" timestamp
);
ALTER TABLE "atb_edit_log_t" ADD CONSTRAINT "atb_edit_log__pk"
	PRIMARY KEY ("ng_id");
CREATE INDEX "atb_edit_log__select__i" ON "atb_edit_log_t" ("ng_book_id" ASC,"ng_user_id" ASC);


CREATE TABLE "atb_page_t"
(
	"ng_id" bigint NOT NULL DEFAULT nextval(('"atb_page__id__seq"'::text)::regclass),
	"ng_book_id" bigint NOT NULL,
	"sz_name" varchar(127)	 NOT NULL,
	"sz_caption" varchar(127)	 NOT NULL,
	"nt_order" integer NOT NULL DEFAULT 0,
	"sz_file" varchar(255)	,
	"sz_store_path" varchar(255)	 NOT NULL,
	"ng_ctor_id" bigint NOT NULL,
	"ng_uper_id" bigint NOT NULL,
	"ts_create" timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
	"ts_update" timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
	"nt_r_state" integer NOT NULL DEFAULT 1,
	"nt_r_version" integer NOT NULL DEFAULT 1
);
ALTER TABLE "atb_page_t" ADD CONSTRAINT "atb_page__pk"
	PRIMARY KEY ("ng_id");
CREATE INDEX "atb_page__select__i" ON "atb_page_t" ("ng_book_id" ASC,"nt_order" ASC);

CREATE TABLE "atb_res_t"
(
	"ng_id" bigint NOT NULL DEFAULT nextval(('"atb_res__id__seq"'::text)::regclass),
	"ng_book_id" bigint NOT NULL,
	"ng_page_id" bigint NOT NULL,
	"sz_name" varchar(127)	 NOT NULL,
	"sz_caption" varchar(127)	 NOT NULL,
	"sz_cover" varchar(255)	,
	"nt_kind" integer NOT NULL,
	"nt_order" integer NOT NULL DEFAULT 0,
	"nt_x_pos" integer NOT NULL DEFAULT 0,
	"nt_y_pos" integer NOT NULL DEFAULT 0,
	"nt_w_len" integer NOT NULL DEFAULT 0,
	"nt_h_len" integer NOT NULL DEFAULT 0,
	"tx_content" text,
	"sz_uri" varchar(1024)	,
	"sz_file" varchar(127)	 NOT NULL,
	"sz_store_path" varchar(255)	 NOT NULL,
	"ng_ctor_id" bigint NOT NULL,
	"ng_uper_id" bigint NOT NULL,
	"ts_create" timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
	"ts_update" timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
	"nt_r_state" integer NOT NULL DEFAULT 1,
	"nt_r_ver" integer NOT NULL DEFAULT 1
);
ALTER TABLE "atb_res_t" ADD CONSTRAINT "atb_res__pk"
	PRIMARY KEY ("ng_id");
CREATE INDEX "atb_res__select__pk" ON "atb_res_t" ("ng_book_id" ASC,"ng_page_id" ASC,"nt_kind" ASC,"nt_order" ASC);



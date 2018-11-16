
CREATE SEQUENCE sys_user__id__seq INCREMENT 1 START 1;
CREATE SEQUENCE sys_log__id__seq INCREMENT 1 START 1;
CREATE SEQUENCE sys_role__id__seq INCREMENT 1 START 1;
CREATE SEQUENCE sys_role_mod__id__seq INCREMENT 1 START 1;
CREATE SEQUENCE sys_user_role__id__seq INCREMENT 1 START 1;
CREATE SEQUENCE sys_user_qa__id__seq INCREMENT 1 START 1;
CREATE SEQUENCE sys_ucverify__id__seq INCREMENT 1 START 1;


CREATE TABLE sys_user_t
(
	ng_id bigint NOT NULL DEFAULT nextval('sys_user__id__seq'),
	sz_uname varchar(127)	 NOT NULL,
	sz_nkname varchar(63)	 NOT NULL,
	sz_pwd varchar(127)	 NOT NULL,
	sz_email varchar(127)	,
	sz_mobile varchar(15)	,
	nt_kind INTEGER NOT NULL default 2,
	nt_gender INTEGER NOT NULL default -1,
	sz_slogan varchar(255),
	sz_avatar varchar(255),
	bn_locked boolean NOT NULL DEFAULT false,
	ts_locked timestamp,	
	nt_fcnt integer NOT NULL DEFAULT 0,	
	nt_login_cnt integer NOT NULL DEFAULT 0,
	ts_last_login timestamp,
	nt_state integer NOT NULL DEFAULT 0,
	ng_ctor_id bigint,
	ng_uper_id bigint,
	ts_create timestamp NOT NULL,
	ts_update timestamp NOT NULL,
	nt_r_state integer NOT NULL DEFAULT 1,
	nt_r_ver integer NOT NULL DEFAULT 1
);

ALTER TABLE sys_user_t ADD CONSTRAINT sys_user__pk
	PRIMARY KEY (ng_id);
ALTER TABLE sys_user_t ADD CONSTRAINT sys_user__email__ui UNIQUE (sz_email);
ALTER TABLE sys_user_t ADD CONSTRAINT sys_user__mobi__ui UNIQUE (sz_mobile);

CREATE TABLE sys_config_t
(
	sz_key varchar(63) NOT NULL,
	ng_user_id bigint NOT NULL DEFAULT 0,
	sz_value text,
	ng_ctor_id bigint,
	ng_uper_id bigint,
	ts_create timestamp NOT NULL,
	ts_update timestamp NOT NULL,
	nt_r_state integer NOT NULL DEFAULT 1,
	nt_r_ver integer NOT NULL DEFAULT 1
);
ALTER TABLE sys_config_t ADD CONSTRAINT sys_config__pk
	PRIMARY KEY (ng_user_id,sz_key);
	

CREATE TABLE sys_log_t
(
	ng_id bigint NOT NULL DEFAULT nextval('sys_log__id__seq'),
	ng_user_id bigint,
	nt_mod_id integer NOT NULL,
	nt_func_id integer,
	nt_result integer NOT NULL default 0,
	sz_cap varchar(255)	 NOT NULL,	
	tx_log text,
	ts_create timestamp default CURRENT_TIMESTAMP
);

ALTER TABLE sys_log_t ADD CONSTRAINT sys_log__pk PRIMARY KEY (ng_id);
CREATE INDEX sys_log__select__i ON sys_log_t (nt_mod_id ASC,nt_func_id ASC,ts_create ASC);
CREATE INDEX sys_log__user__i ON sys_log_t (ng_user_id ASC,ts_create ASC);


CREATE TABLE sys_module_t
(
	ng_id integer NOT NULL,
	ng_p_id integer,
	sz_cap varchar(63)	 NOT NULL,
	sz_icon varchar(63)	 NOT NULL,
	nt_kind integer NOT NULL DEFAULT 32,
	nt_partial integer NOT NULL DEFAULT 3,
	sz_uri varchar(127)	,
	bn_anonym boolean NOT NULL DEFAULT false,
	bn_user boolean NOT NULL DEFAULT false,
	nt_level integer NOT NULL DEFAULT 3,
	nt_order integer NOT NULL DEFAULT 99,
	sz_id_path varchar(255)	 NOT NULL,
	bn_enable boolean NOT NULL DEFAULT true,
	bn_visible boolean NOT NULL DEFAULT true,
	sz_deps varchar(255)	
)
;

ALTER TABLE sys_module_t ADD CONSTRAINT sys_module__pk
	PRIMARY KEY (ng_id);
CREATE INDEX sys_module__select__i ON sys_module_t (nt_kind asc,nt_level ASC,nt_order ASC);

CREATE TABLE sys_role_t
(
	ng_id bigint NOT NULL DEFAULT nextval('sys_role__id__seq'),
	sz_name varchar(63)	 NOT NULL,
	sz_cap varchar(63)	 NOT NULL,
	nt_kind integer NOT NULL DEFAULT 32,
	ng_ctor_id bigint,
	ng_uper_id bigint,
	ts_create timestamp NOT NULL,
	ts_update timestamp NOT NULL,
	nt_r_state integer NOT NULL DEFAULT 1,
	nt_r_ver integer NOT NULL DEFAULT 1
);

ALTER TABLE sys_role_t ADD CONSTRAINT sys_role__pk
	PRIMARY KEY (ng_id);
ALTER TABLE sys_role_t ADD CONSTRAINT sys_role__name__ui UNIQUE (sz_name);


CREATE TABLE sys_role_mod_t
(
	ng_role_id bigint NOT NULL,
	ng_mod_id integer NOT NULL
);
ALTER TABLE sys_role_mod_t ADD CONSTRAINT sys_role_mod__pk
	PRIMARY KEY (ng_role_id,ng_mod_id);

CREATE TABLE sys_user_role_t
(
	ng_user_id bigint NOT NULL,
	ng_role_id bigint NOT NULL
);
ALTER TABLE sys_user_role_t ADD CONSTRAINT sys_user_role__pk
	PRIMARY KEY (ng_user_id,ng_role_id);


CREATE TABLE sys_user_qa_t
(
	ng_id bigint NOT NULL DEFAULT nextval('sys_user_qa__id__seq'),
	ng_user_id bigint NOT NULL,
	sz_question varchar(255)	 NOT NULL,
	sz_answer varchar(255)	 NOT NULL,
	nt_order integer NOT NULL,
	ts_create timestamp NOT NULL,
	ts_update timestamp NOT NULL,
	nt_r_ver integer NOT NULL DEFAULT 1
);

ALTER TABLE sys_user_qa_t ADD CONSTRAINT sys_user_qa__pk
	PRIMARY KEY (ng_id);
CREATE INDEX sys_user_qa__user__i ON sys_user_qa_t (ng_user_id ASC,nt_order ASC);

CREATE TABLE sys_ucverify_t
(
	ng_id bigint NOT NULL DEFAULT nextval(('sys_ucverify__id__seq'::text)::regclass),
	ng_user_id bigint NOT NULL,
	sz_code varchar(255)	 NOT NULL,
	ts_send timestamp NOT NULL,
	nt_kind integer NOT NULL
);

ALTER TABLE sys_ucverify_t ADD CONSTRAINT sys_ucverify__pk
	PRIMARY KEY (ng_id);
CREATE INDEX sys_ucverify__select__i ON sys_ucverify_t (ng_user_id ASC,nt_kind ASC,ts_send DESC);



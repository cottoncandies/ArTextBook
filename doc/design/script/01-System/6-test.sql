insert into sys_module_t
(
	ng_id,ng_p_id,sz_cap,sz_icon,nt_kind,nt_partial,sz_uri,bn_anonym,bn_user,nt_level,nt_order,sz_id_path,bn_enable,bn_visible,sz_deps
)values(
	130000,null,'�̲Ĺ���','icon-users',16,3,null,false,false,1,9920,',130000,',true,true,null
),(
	130100,130000,'�̲��ϴ�','icon-users',32,3,'/TextBook/Upload',false,false,2,100,',130000,130100,',true,true,null
),(
	130200,130000,'�̲��б�','icon-users',32,3,'/TextBook/List',false,false,2,200,',130000,130200,',true,true,null
),(
	160000,null,'�̲�API','icon-users',256,0,null,false,false,1,100,',160000,',true,true,null
),(
	160100,160000,'�ϴ��̲�API','icon-users',512,0,'/TextBookApi/UploadFile',false,true,2,100,',160000,160100,',true,true,null
),(
	160101,160000,'�ϴ��̲�form��API','icon-users',512,0,'/TextBookApi/UploadForm',false,true,2,101,',160000,160101,',true,true,null
),(
	160102,160000,'��ȡ�����꼶API','icon-users',512,0,'/TextBookApi/GetGrades',false,true,2,102,',160000,160102,',true,true,null
),(
	160103,160000,'��ȡ����ѧ��API','icon-users',512,0,'/TextBookApi/GetSubjects',false,true,2,103,',160000,160103,',true,true,null
),(
	160104,160000,'��ȡ���г�����API','icon-users',512,0,'/TextBookApi/GetPublishs',false,true,2,104,',160000,160104,',true,true,null
),(
	160105,160000,'��ȡ���а汾API','icon-users',512,0,'/TextBookApi/GetEditions',false,true,2,105,',160000,160105,',true,true,null
),(
	160106,160000,'��ȡ���н̲�API','icon-users',512,0,'/TextBookApi/GetTextBooks',false,true,2,106,',160000,160106,',true,true,null
);

insert into atb_textbook_t
(
sz_oid,sz_caption,ng_grade_id,ng_edition_id,ng_subject_id,ng_publish_id,sz_src_store,sz_src_md5,sz_dst_store,sz_dst_md5
,sz_img_path,sz_res_path,ng_ctor_id,ng_uper_id
)values(
'123123','ar�鱾1',1,1,1,1,'sz_src_store','sz_src_md5','sz_dst_store','sz_dst_md5','sz_img_path','sz_res_path',1,1
),(
'123124','ar�鱾2',1,1,1,1,'sz_src_store','sz_src_md5','sz_dst_store','sz_dst_md5','sz_img_path','sz_res_path',1,1
),(
'123125','ar�鱾3',1,1,1,1,'sz_src_store','sz_src_md5','sz_dst_store','sz_dst_md5','sz_img_path','sz_res_path',1,1
);


delete from sys_role_mod_t where ng_role_id = 1;

insert into sys_role_mod_t
(
	ng_role_id,ng_mod_id
)
select 1, ng_id from sys_module_t;


//ѧ�Ʊ�
INSERT INTO atb_subject_t(sz_caption,ng_ctor_id,ng_uper_id) VALUES ('����',1,1);
INSERT INTO atb_subject_t(sz_caption,ng_ctor_id,ng_uper_id) VALUES ('��ѧ',1,1);
INSERT INTO atb_subject_t(sz_caption,ng_ctor_id,ng_uper_id) VALUES ('Ӣ��',1,1);
INSERT INTO atb_subject_t(sz_caption,ng_ctor_id,ng_uper_id) VALUES ('����',1,1);
INSERT INTO atb_subject_t(sz_caption,ng_ctor_id,ng_uper_id) VALUES ('��ʷ',1,1);
INSERT INTO atb_subject_t(sz_caption,ng_ctor_id,ng_uper_id) VALUES ('����',1,1);
INSERT INTO atb_subject_t(sz_caption,ng_ctor_id,ng_uper_id) VALUES ('����',1,1);
INSERT INTO atb_subject_t(sz_caption,ng_ctor_id,ng_uper_id) VALUES ('��ѧ',1,1);
INSERT INTO atb_subject_t(sz_caption,ng_ctor_id,ng_uper_id) VALUES ('����',1,1);

//�������
INSERT INTO atb_publish_t(sz_caption,ng_ctor_id,ng_uper_id) VALUES ('�������������',1,1);
INSERT INTO atb_publish_t(sz_caption,ng_ctor_id,ng_uper_id) VALUES ('���ӹ�ҵ������',1,1);

//�汾��
INSERT INTO atb_edition_t(sz_caption,ng_ctor_id,ng_uper_id) VALUES ('2013�˽̰�',1,1);
INSERT INTO atb_edition_t(sz_caption,ng_ctor_id,ng_uper_id) VALUES ('2015�˽̰�',1,1);
INSERT INTO atb_edition_t(sz_caption,ng_ctor_id,ng_uper_id) VALUES ('2013�ս̰�',1,1);
INSERT INTO atb_edition_t(sz_caption,ng_ctor_id,ng_uper_id) VALUES ('2015�ս̰�',1,1);
INSERT INTO atb_edition_t(sz_caption,ng_ctor_id,ng_uper_id) VALUES ('2013��̰�',1,1);
INSERT INTO atb_edition_t(sz_caption,ng_ctor_id,ng_uper_id) VALUES ('2015��̰�',1,1);


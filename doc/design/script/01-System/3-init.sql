
alter sequence sys_user__id__seq restart with 1;

insert into sys_user_t
(
	ng_id,sz_uname,sz_nkname,sz_pwd,sz_email,sz_mobile,nt_kind
)values(
	1,'Administrator','Administrator',md5('admin'),'admin@system.xyz','00000000001',1
),(
	2,'Automatic','Automatic',md5('Automatic'),'Automatic@system.xyz','00000000002',0
),(
	3,'Anonymous','Anonymous',md5('Anonymous'),'Anonymous@system.xyz','00000000003',0
);

alter sequence sys_user__id__seq restart with 129;

alter sequence sys_role__id__seq restart with 1;

insert into sys_role_t
(
	ng_id,sz_name,sz_cap,nt_kind
)values(
	1,'Athenas','超级管理员',1
),(
	2,'Managers','运维管理员',2
),(
	3,'Administrators','管理员',16
),(
	4,'Users','用户',32
);
alter sequence sys_role__id__seq restart with 129;

insert into sys_user_role_t
(
	ng_user_id,ng_role_id
)values
((select ng_id from sys_user_t where sz_uname='Administrator' ),(select ng_id from sys_role_t where sz_name='Athenas'));

-- 100000<X<200000 Kernel
insert into sys_module_t
(
	ng_id,ng_p_id,sz_cap,sz_icon,nt_kind,nt_partial,sz_uri,bn_anonym,bn_user,nt_level,nt_order,sz_id_path,bn_enable,bn_visible,sz_deps
)values(
	100000,null,'通用功能','icon-users',1,3,null,true,true,1,1,',100000,',true,true,null
),(
	100100,100000,'网站首页','icon-users',2,1,'/Home/Index',true,true,2,100,',100000,100100,',true,false,null
),(
	100200,100000,'关于','icon-users',2,3,'/Home/About',true,true,2,200,',100000,100200,',true,true,null
),(
	100300,100000,'ERROR','icon-users',2,3,'/Home/Error',true,true,2,300,',100000,100300,',true,true,null
),(
	100400,100000,'用户登陆','icon-users',2,3,'/Home/Login',true,true,2,400,',100000,100400,',true,true,'150101'
),(
	100500,100000,'系统退出','icon-users',2,3,'/Home/Logout',false,true,2,500,',100000,100500,',true,true,null
),(
	100600,100000,'工作台','icon-users',2,2,'/Home/Main',false,true,2,600,',100000,100600,',true,true,null
);

insert into sys_module_t
(
	ng_id,ng_p_id,sz_cap,sz_icon,nt_kind,nt_partial,sz_uri,bn_anonym,bn_user,nt_level,nt_order,sz_id_path,bn_enable,bn_visible,sz_deps
)values(
	110000,null,'个人设置','icon-users',16,1,null,false,false,1,9900,',110000,',true,false,null
),(
	110100,110000,'个人信息','icon-users',32,1,'/User/Profile',false,false,2,100,',110000,110100,',true,false,null
),(
	110200,110000,'修改密码','icon-users',32,1,'/User/ChangePassword',false,false,2,200,',110000,110200,',true,false,null
),(
	120000,null,'系统管理','icon-users',16,2,null,false,false,1,9910,',120000,',true,true,null
),(
	120100,120000,'用户管理','icon-users',32,2,'/User/Index',false,false,2,100,',120000,120100,',true,true,null
),(
	120200,120000,'角色管理','icon-users',32,2,'/Role/Index',false,false,2,200,',120000,120200,',true,true,null
),(
	120300,120000,'日志查询','icon-users',32,2,'/Log/Index',false,false,2,300,',120000,120300,',true,true,null
),(
	150000,null,'用户API','icon-users',256,0,null,false,false,1,100,',150000,',true,true,null
),(
	150100,150000,'心跳接口','icon-users',512,0,'/Api/Ping',false,true,2,100,',150000,150100,',true,true,null
),(
	150101,150000,'用户登陆API','icon-users',512,0,'/UserApi/Login',true,true,2,101,',150000,150101,',true,true,null
),(
	150102,150000,'用户退出API','icon-users',512,0,'/UserApi/Logout',false,true,2,102,',150000,150102,',true,true,null
);


insert into sys_role_mod_t
(
	ng_role_id,ng_mod_id
)
select 1, ng_id from sys_module_t;


INSERT INTO tbl_TravelArticleClass(ClassName,IsSystem,SortRule) VALUES('����',1,0)
INSERT INTO tbl_TravelArticleClass(ClassName,IsSystem,SortRule) VALUES('����ָ��',2,0)
INSERT INTO tbl_TravelArticleClass(ClassName,IsSystem,SortRule) VALUES('��ȫָ��',3,0)
INSERT INTO tbl_TravelArticleClass(ClassName,IsSystem,SortRule) VALUES('֧����ȡƱ',4,0)
INSERT INTO tbl_TravelArticleClass(ClassName,IsSystem,SortRule) VALUES('��ͨ�붩��',5,0)
INSERT INTO tbl_TravelArticleClass(ClassName,IsSystem,SortRule) VALUES('��Ա����',6,0)

INSERT INTO [tbl_Webmaster]  ([Username],[Password],[MD5Password],[Realname],[Telephone],[Fax],[Mobile],[Permissions],[IsEnable],[IsAdmin],[CreateTime])  VALUES  ('Admin','000000','670b14728ad9902aecba32e22fa4f6bd','��վ����Ա','','','','','1','1',GETDATE())





--2013-07-09

--���붨������Ѷ���
INSERT INTO tbl_TravelArticleClass(ClassName,IsSystem,SortRule) VALUES('������',7,0)
--Admin�˺ŷ�������Ȩ��
UPDATE tbl_Webmaster SET [Permissions]='101,102,103,104,201,202,203,204,301,302,303,401,501,502,503,504,505,506,507,508,509,510,511,601,602,10001,10002' WHERE Id=2

--�޸����ݣ��Ƶ�-����λ�ã��ر꣩��tbl_HotelLandMarks�����CityId�ֶ�(���б��)
ALTER TABLE tbl_HotelLandMarks ADD
	CityId int not NULL DEFAULT (0)
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���б��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_HotelLandMarks', @level2type=N'COLUMN',@level2name=N'CityId'
GO

--��Ѷ���Ա�
if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_TravelArticleLY')
            and   type = 'U')
   drop table tbl_TravelArticleLY
go
/*==============================================================*/
/* Table: tbl_TravelArticleLY                                   */
/*==============================================================*/
create table tbl_TravelArticleLY (
   LiuYanId             char(36)             not null,
   ArticleID            char(36)             not null,
   MemberID             char(36)             not null,
   LiuYanShiJian        datetime             not null default getdate(),
   LiuYanContet         nvarchar(max)         null,
   HuiFuContet          nvarchar(max)         null,
   IsCheck              char(1)              not null default '0',
   OperatorId           char(36)             null default '0',
   IssueTime            datetime             null,
   constraint PK_TBL_TRAVELARTICLELY primary key (LiuYanId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��Ѷ����',
   'user', @CurrentUser, 'table', 'tbl_TravelArticleLY'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���Ա��',
   'user', @CurrentUser, 'table', 'tbl_TravelArticleLY', 'column', 'LiuYanId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��Ѷ���',
   'user', @CurrentUser, 'table', 'tbl_TravelArticleLY', 'column', 'ArticleID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��Ա���',
   'user', @CurrentUser, 'table', 'tbl_TravelArticleLY', 'column', 'MemberID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'tbl_TravelArticleLY', 'column', 'LiuYanShiJian'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'tbl_TravelArticleLY', 'column', 'LiuYanContet'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ظ�����',
   'user', @CurrentUser, 'table', 'tbl_TravelArticleLY', 'column', 'HuiFuContet'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƿ����',
   'user', @CurrentUser, 'table', 'tbl_TravelArticleLY', 'column', 'IsCheck'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����',
   'user', @CurrentUser, 'table', 'tbl_TravelArticleLY', 'column', 'OperatorId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ʱ��',
   'user', @CurrentUser, 'table', 'tbl_TravelArticleLY', 'column', 'IssueTime'
go


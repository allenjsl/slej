

use hzjalydb
go
create table Temp_Hotel_City
(
CITY_CODE  varchar(max), --���д���
CITY_NAME  varchar(max), --��������
CITY_PINYIN  varchar(max), --����ƴ��
CITY_PYFW  varchar(max), --ƴ������ĸ
COUNTRY_CODE  varchar(max),--���Ҵ���
Country_Name varchar(max), --��������
PROVINCE  varchar(max) --ʡ��
)

GO

create table Temp_Hotel_BrandInfo
(
ID  varchar(max), --Ψһ��ʶ
BRAND_CODE  varchar(max), ---Ʒ�ƴ���
BRAND_NAME  varchar(max), --Ʒ������
CHAIN_CODE  varchar(max), --�Ƶ��������Ŵ���
DESCP  varchar(max) --Ʒ������
)

GO

create table Temp_Hotel_HotelAmenity
(
HOTEL_CODE  varchar(max), --�Ƶ����
AMENITY_NAME  varchar(max), --��ʩ����
AMENITY_STATUS  varchar(max), --��ʩ״̬
AMENITY_TYPE  varchar(max) --��ʩ���
)

GO

create table Temp_Hotel_HotelAccepted
(
HOTEL_CODE  varchar(max) , --�Ƶ����
CARD_CODE  varchar(max), --���ÿ�����
CARD_NAME  varchar(max), --���ÿ�����
CARD_TYPE  varchar(max) --���ÿ�����
)

create table Temp_Hotel_HotelTraffic
(
HOTEL_CODE  varchar(max) , --�Ƶ����
TRAFFIC_NAME  varchar(max), --��ͨ��Ϣ����
DISTANCE  varchar(max), --����
CAR_INTERVAL  varchar(max), --����
FOOT_INTERVAL  varchar(max), --����
CATEGORY  varchar(max) --���
)

GO

create table Temp_Hotel_Landmark
(
CITY_CODE  varchar(max) not null, --���д���
LANDMARK_NAME  varchar(max)  not null, --�ر�����
CITY_NAME  varchar(max), --��������
CATEGORY  varchar(max), --���
COUNTRY_CODE  varchar(max), --���Ҵ���
HOTELS  varchar(max) --������Ƶ� code ����
)
GO
--alter table Hotel_Landmark  
--add primary key nonclustered (CITY_CODE,LANDMARK_NAME,CATEGORY) 

GO

create table Temp_Hotel_HotelInfo
(
HOTEL_CODE  varchar(max), --�Ƶ����
HOTEL_NAMECN  varchar(max), --�Ƶ���������
HOTEL_NAMEEN  varchar(max), --�Ƶ�Ӣ������
RANK_CODE  varchar(max), --�Ǽ�
CITY_CODE  varchar(max), --���д���
COUNTRY_CODE  varchar(max), --���Ҵ���
PROVINCE  varchar(max), --ʡ��
HOTEL_ADDRESS  varchar(max), --�Ƶ��ַ
POSTAL_CODE  varchar(max), --�ʱ�
TEL  varchar(max), --�绰
OPEN_DATE  varchar(max), --��ҵʱ��
FIX_MENT  varchar(max), --װ��ʱ��
ROOM_QUANTITY  varchar(max), --������
FLOOR  varchar(max), --¥����
FAX  varchar(max), --����
DISTRICT  varchar(max), --������
LONG_DESC  varchar(max), --���
LATITUDE  varchar(max), ---γ��
LONGITUDE  varchar(max), --����
IMG_DT  varchar(max), -- ����ͼƬ
STATUS  varchar(max), --�Ƶ�״̬
IMG_KF  varchar(max), --�ͷ�ͼƬ
IMG_WJ  varchar(max), --�⾰ͼƬ
BRAND_CODE  varchar(max) --Ʒ�ƴ���
)

GO


create table Temp_Hotel_RoomType
(
HOTEL_CODE  varchar(max) not null, --�Ƶ����
ROOM_TYPE_CODE  varchar(max) not null, --���ʹ���
INV_STATUS varchar(max),--����ֵ
NO_SMOKING varchar(max),--�Ƿ�����
BED_TYPE varchar(max),--����
TOTAL_NUMBER varchar(max),--��������
FLOOR varchar(max),--¥��
ROOM_AREA varchar(max),--�������
MAX_ADD_BED varchar(max),--���Ӵ�����
DESCP varchar(max),--����
INV_TYPE varchar(max),--��������
CATEGORY varchar(max),--��������
ROOM_VIEW varchar(max),--���;���
MAX_GUEST_NUM varchar(max),--�����ס������Ŀ
INTERNET varchar(max),--���
EN_INV_TYPE varchar(max),--����Ӣ������
BED_AREA varchar(max),--�����
STATUS  varchar(max) --����״̬
)
GO
--alter table Hotel_RoomType  
--add primary key nonclustered (HOTEL_CODE,ROOM_TYPE_CODE) 
GO

create table Temp_Hotel_RatePlan_Temp
(
HOTEL_CODE  varchar(max) not null, --�Ƶ����
ROOM_TYPE_CODE  varchar(max) not null, --���ʹ���
RATE_PLAN_CODE  varchar(max)  not null, --�۸�ƻ�����
START_DATE  varchar(max) not null, --��ʼʱ��
END_DATE varchar(max),--����ʱ��
MAX_LOS varchar(max),--�����ס����
STATUS varchar(max),--����״̬
LEADING_TIME varchar(max),--��ǰԤ������
VENDOR_CODE varchar(max),--��Ӧ�̴���
IS_SIGN varchar(max),--�Ƿ�����ǩ�Ƶ�
MIN_LOS varchar(max),--��С��ס����
TIME_STAMP  varchar(max) --ʱ���
)
GO
--alter table Hotel_RatePlan_Temp  
--add primary key nonclustered (HOTEL_CODE,ROOM_TYPE_CODE,RATE_PLAN_CODE,START_DATE) 
GO

create table Temp_Hotel_RoomRate_Temp
(
HOTEL_CODE  varchar(max) not null, --�Ƶ����
ROOM_TYPE_CODE  varchar(max) not null, --���ʹ���
RATE_PLAN_CODE  varchar(max)  not null, --�۸�ƻ�����
START_DATE  varchar(max) not null, --��ʼʱ��
END_DATE varchar(max),--����ʱ��
AMOUNT_PRICE varchar(max),--�۸�
CURRENCY varchar(max),--���Ҵ���
RATE_PLAN_NAME  varchar(max), --�۸�ƻ�����
PAYMENT_METHOD  varchar(max), --֧����ʽ
FEE_PERCENT varchar(max),--����
VENDER_CODE varchar(max),--��Ӧ�̴���
DISPLAY_PRICE varchar(max),--���м�
TIME_STAMP varchar(max),--ʱ���
FREE_MEAL  varchar(max) --���
)
GO
--alter table Hotel_RoomRate_Temp  
--add primary key nonclustered (HOTEL_CODE,ROOM_TYPE_CODE,RATE_PLAN_CODE,START_DATE) 
GO

create table Temp_Hotel_RoomRate
(
HOTEL_CODE varchar(max) not null,--�Ƶ����
ROOM_TYPE_CODE varchar(max) not null,--���ʹ���
RATE_PLAN_CODE  varchar(max)  not null, --�۸�ƻ�����
START_DATE varchar(max) not null,--��ʼʱ��
END_DATE varchar(max),--����ʱ��
AMOUNT_PRICE varchar(max),--�۸�
CURRENCY varchar(max),--���Ҵ���
RATE_PLAN_NAME  varchar(max), --�۸�ƻ�����
PAYMENT_METHOD  varchar(max), --֧����ʽ
FEE_PERCENT varchar(max),--����
VENDER_CODE varchar(max),--��Ӧ�̴���
DISPLAY_PRICE varchar(max),--���м�
TIME_STAMP varchar(max),--ʱ���
IS_SIGN varchar(max),--�Ƿ�Ϊ��ǩ�Ƶ�
FREE_MEAL varchar(max),--���
STATUS varchar(max),--״̬
LOAD_TIME  varchar(max) --ʱ��� 2
)
GO
--alter table Hotel_RoomRate  
--add primary key nonclustered (HOTEL_CODE,ROOM_TYPE_CODE,RATE_PLAN_CODE,START_DATE) 

GO

create table Temp_Hotel_GuaranteePolicy
(
HOTEL_CODE  varchar(max) not null, --�Ƶ����
ROOM_TYPE_CODE  varchar(max)  not null , --���ʹ���
RATE_PLAN_CODE  varchar(max) not null, --�۸�ƻ�����
STATUS varchar(max),--״̬
SHORT_DESC varchar(max),--��Ҫ����
GUARANTEE_TYPE varchar(max),--��������
GUARANTEE_METHOD varchar(max),--������ʽ
NUMOF_ROOM2 varchar(max),--��ס������
FEE_VALUE2 varchar(max),--�շѾ���ֵ
HOLD_TIME2 varchar(max),--����ʱ��
GUARANTEE_DATE2 varchar(max),--��ǰԤ������
DAYSOF_STAY varchar(max),--��ס����
FEE_VALUE varchar(max),--�շѾ���ֵ
HOLD_TIME varchar(max),--����ʱ��
GUARANTEE_DATE varchar(max),--��ǰԤ������
UNITOF_FEE varchar(max),--�շѵ�λ
DAYSOF_STAY3 varchar(max),--��ס����
FEE_VALUE3 varchar(max),--�շѾ���ֵ
NUMOF_ROOM3 varchar(max),--��ס������
GUARANTEE_DATE3 varchar(max),--��ǰԤ������
HOLD_TIME3 varchar(max),--����ʱ��
NUMOF_ROOM varchar(max),--��ס������
UNITOF_FEE2 varchar(max),--�շѵ�λ
UNITOF_FEE3 varchar(max),--�շѵ�λ
LONG_DESC varchar(max),--��ϸ����
START_DATE varchar(max),--��ʼʱ��
END_DATE  varchar(max) --����ʱ��
)
GO
--alter table Hotel_GuaranteePolicy  
--add primary key nonclustered (HOTEL_CODE,ROOM_TYPE_CODE,RATE_PLAN_CODE) 
GO

create table Temp_Hotel_Order
(
ORDERID  varchar(max), --��������
STATUS varchar(max),--����״̬
HOTEL_CODE varchar(max),--�Ƶ����
HOTEL_NAME varchar(max),--�Ƶ�����
HOTEL_ADDRESS varchar(max),--�Ƶ��ַ
HOTEL_RANK varchar(max),--�Ƶ��Ǽ�
CITY_CODE varchar(max),--�Ƶ����ڳ��д���
ROOM_TYPE_CODE varchar(max),--���ʹ���
ROOM_TYPE_NAME varchar(max),--��������
RATE_PLAN_CODE varchar(max),--�۸�ƻ�����
RATE_PLAN_NAME varchar(max),--�۸�ƻ�����
VENDOR_CODE varchar(max),--��Ӧ�̴���
CHECK_IN_DATE varchar(max),--��סʱ��
CHECK_OUT_DATE varchar(max),--���ʱ��
CREATE_TIME varchar(max),--����ʱ��
UPDATE_TIME varchar(max),--����ʱ��
FIRST_PRICE varchar(max),--���ռ۸�
TOTAL_PRICE varchar(max),--�ܼ۸�
BED_TYPE varchar(max),--����
INTERNET varchar(max),--���
FREE_MEAL varchar(max),--���
ROOM_QUANTITY varchar(max),--��������
ROOM_NIGHTS varchar(max),--��סҹ����
SPECIAL_REQUEST varchar(max),--����Ҫ��
ARRIVE_EARLY_TIME varchar(max),--���絽��ʱ��
ARRIVE_LATE_TIME varchar(max),--������ʱ��
PAYMENT varchar(max),--֧����ʽ
PAYMET_STATUS varchar(max),--֧��״̬
[USER_ID]  varchar(max), --�û�����
GUEST_NAME  varchar(max), --�ͻ�����
CONTACT_NAME  varchar(max), --��ϵ������
CONTACT_EMAIL  varchar(max), --��ϵ������
CONTACT_MOBILE  varchar(max), --��ϵ�˵绰
CHECK_IN_STATUS  varchar(max) --��ס״̬
)

GO

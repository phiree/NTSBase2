DECLARE  @RunScript varchar(50);
SET @RunScript ='��Ҫ��յ�������';
IF @RunScript != '��Ҫ��յ�������'
BEGIN
--RAISERROR ('Raise Error does not stop processing, so we will call GOTO to skip over the script', 1, 1);
GOTO Skipper -- This will skip over the script and go to Skipper
END


select * from t_tabledescription where   fdescription like '%���۱���%'
--select * from t_fielddescription where ftableid = '17' and fdescription like '%�Ƽ�%'
--select * from ictransactiontype where ftrantype=2 --��Ʒ��ⵥ
--����ⵥ�� ftablename='t_RP_SystemProfile'
select * from ICStockBillentry
alter table ICStockBill disable trigger ICStockBill_DEL
delete from icstockbill
alter table ICStockBill enable trigger ICStockBill_DEL
delete from icstockbillentry
--����֪ͨ��

select * from  POInStock
alter table POInStock disable trigger POInStock_DEL

delete from  POInStock
alter table POInStock enable trigger POInStock_DEL

delete from  POInStockentry
--�ɹ�����
select * from POOrder
alter table poorder disable trigger POOrder_DEL

delete from poorder
alter table poorder enable trigger POOrder_DEL

delete from poorderentry
--����֪ͨ��
select * from SEOutStock
delete from SEOutStock
delete from SEOutStockentry
--���۶���
select * from SEOrder
alter table seorder disable trigger SEOrder_DEL
delete from seorder
alter table seorder enable trigger SEOrder_DEL
delete from seorderentry
--�ɹ�����
select * from PORequest
alter table PORequest disable trigger PORequest_Del
delete from PORequest
alter table PORequest enable trigger PORequest_Del

delete from PORequestentry
--��ͬ
select * from t_RPContractentry
delete from t_RPContract
delete from t_RPContractentry
--����
select * from ExpOutReqMain
delete from ExpOutReqMain
delete from ExpOutReqentry
--��������
select * from t_rp_PayApplyBillentry
delete from t_rp_PayApplyBill
delete from t_rp_PayApplyBillentry
--���۱���
select * from PORFQentry
alter table PORFQ
disable trigger PORFQ_Del


delete from PORFQ



delete from PORFQentry
alter table PORFQ
enable trigger PORFQ_Del
--�ո�����ϸ
delete from t_rp_arbillofsh
--��Ϣ���ĵ������б�
delete from ICClassMCTaskCenter
--��Ϣ���ĵ���Ϣ��ʾ
delete from t_message
----
---��װ��λ��ͷ��ExpItemPacking
delete from ExpItemPackingEntry
--��װ��λ���壺ExpItemPackingEntry
delete from ExpItemPacking


Skipper:


print '�����ȷ��Ҫɾ�����е�������?
'
+
+db_name()
+ '
...
����Ŀ�����ݿ��Ƿ���ȷ
...
��10����ȷ�ϸò����Ǳ����������....
.........
��������Ҫ������,���޸Ľű�,��ʼִ��.
���Ҫɾ��ô?
���Ҫɾ��ô?
���Ҫɾ��ô?
���Ҫɾ��ô?
���Ҫɾ��ô?
���Ҫɾ��ô?
���Ҫɾ��ô?
���Ҫɾ��ô?
���Ҫɾ��ô?
���Ҫɾ��ô?
'

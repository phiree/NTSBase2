DECLARE  @RunScript varchar(50);
SET @RunScript ='我要清空单据数据';
IF @RunScript != '我要清空单据数据'
BEGIN
--RAISERROR ('Raise Error does not stop processing, so we will call GOTO to skip over the script', 1, 1);
GOTO Skipper -- This will skip over the script and go to Skipper
END


select * from t_tabledescription where   fdescription like '%销售报价%'
--select * from t_fielddescription where ftableid = '17' and fdescription like '%计价%'
--select * from ictransactiontype where ftrantype=2 --产品入库单
--出入库单据 ftablename='t_RP_SystemProfile'
select * from ICStockBillentry
alter table ICStockBill disable trigger ICStockBill_DEL
delete from icstockbill
alter table ICStockBill enable trigger ICStockBill_DEL
delete from icstockbillentry
--收料通知单

select * from  POInStock
alter table POInStock disable trigger POInStock_DEL

delete from  POInStock
alter table POInStock enable trigger POInStock_DEL

delete from  POInStockentry
--采购订单
select * from POOrder
alter table poorder disable trigger POOrder_DEL

delete from poorder
alter table poorder enable trigger POOrder_DEL

delete from poorderentry
--发货通知单
select * from SEOutStock
delete from SEOutStock
delete from SEOutStockentry
--销售订单
select * from SEOrder
alter table seorder disable trigger SEOrder_DEL
delete from seorder
alter table seorder enable trigger SEOrder_DEL
delete from seorderentry
--采购申请
select * from PORequest
alter table PORequest disable trigger PORequest_Del
delete from PORequest
alter table PORequest enable trigger PORequest_Del

delete from PORequestentry
--合同
select * from t_RPContractentry
delete from t_RPContract
delete from t_RPContractentry
--出运
select * from ExpOutReqMain
delete from ExpOutReqMain
delete from ExpOutReqentry
--付款申请
select * from t_rp_PayApplyBillentry
delete from t_rp_PayApplyBill
delete from t_rp_PayApplyBillentry
--销售报价
select * from PORFQentry
alter table PORFQ
disable trigger PORFQ_Del


delete from PORFQ



delete from PORFQentry
alter table PORFQ
enable trigger PORFQ_Del
--收付款明细
delete from t_rp_arbillofsh
--消息中心的任务列表
delete from ICClassMCTaskCenter
--消息中心的消息提示
delete from t_message
----
---包装单位表头：ExpItemPacking
delete from ExpItemPackingEntry
--包装单位表体：ExpItemPackingEntry
delete from ExpItemPacking


Skipper:


print '如果你确定要删除所有单据数据?
'
+
+db_name()
+ '
...
请检查目标数据库是否正确
...
请10秒钟确认该操作是必须且无误的....
.........
如果你真的要这样做,请修改脚本,开始执行.
真的要删除么?
真的要删除么?
真的要删除么?
真的要删除么?
真的要删除么?
真的要删除么?
真的要删除么?
真的要删除么?
真的要删除么?
真的要删除么?
'

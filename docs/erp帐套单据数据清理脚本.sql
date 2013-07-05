select * from t_tabledescription where   fdescription like '%销售报价%'
select * from t_fielddescription where ftableid = '17' and fdescription like '%计价%'
select * from ictransactiontype where ftrantype=2 --产品入库单
--出入库单据 ftablename='t_RP_SystemProfile'
select * from ICStockBillentry
delete from icstockbill
delete from icstockbillentry
--收料通知单
select * from  POInStock
delete from  POInStock
delete from  POInStockentry
--采购订单
select * from POOrder
delete from poorder
delete from poorderentry
--发货通知单
select * from SEOutStock
delete from SEOutStock
delete from SEOutStockentry
--销售订单
select * from SEOrder
delete from seorder
delete from seorderentry
--采购申请
select * from PORequest
delete from PORequest
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
delete from PORFQ
delete from PORFQentry
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
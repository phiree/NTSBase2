
create procedure [dbo].[ERPService_BillCheckProcess]
as
begin

--报价单
/*销售出库单审核路线还没有弄清楚
销售发票还没做。

*/
select 
'报价单' as billtype,baojiadan.fbillno as billno, fbillid,fcheckname as fcheckname,
case mcr.fcheckdirection when 1 then '启动'  when 2 then '审核'
 when 4 then '驳回' end as checkdirection
 , mcr.fcheckdate as fcheckdate,fcheckto_name as fcheckto_name
 ,case  baojiadan.fmulticheckstatus when 16 then '已审核' end as checkstatus
 from ICClassMCRecord1007006 mcr
 right join PORFQ  as baojiadan
 on mcr.fbillid=baojiadan.finterid
union 
---合同应收---
select 
'合同应收&应付' as billtype,hetongyingshou.fcontractno as billno, fbillid,fcheckname as fcheckname,
case mcr.fcheckdirection when 1 then '启动'  when 2 then '审核'
 when 4 then '驳回' end as checkdirection
 , mcr.fcheckdate as fcheckdate,fcheckto_name as fcheckto_name
 ,case hetongyingshou.fmulticheckstatus  when 16 then '已审核' end  as checkstatus
 from ICClassMCRecord1000019 mcr
 right join t_RPContract  as hetongyingshou
 on mcr.fbillid=hetongyingshou.fcontractid


--销售订单
union
select '销售订单' as billtype,xiaoshoudingdan.fbillno as billno
, fbillid,fcheckname as fcheckname
,case mcr.fcheckdirection when 1 then '启动'  when 2 then '审核'when 4 then '驳回' end as checkdirection
 , mcr.fcheckdate as fcheckdate,fcheckto_name as fcheckto_name
 ,case xiaoshoudingdan.fmulticheckstatus  when 16 then '已审核' end as checkstatus
 from		 ICClassMCRecord1007100 mcr
 right join   seorder  as xiaoshoudingdan
 on mcr.fbillid=xiaoshoudingdan.finterid

union
---出运通知
select '出运通知单' as billtype,chuyuntongzhi.fbillno as billno
, fbillid,fcheckname as fcheckname
,case mcr.fcheckdirection when 1 then '启动'  when 2 then '审核'when 4 then '驳回' end as checkdirection
 , mcr.fcheckdate as fcheckdate,fcheckto_name as fcheckto_name
 ,case chuyuntongzhi.fmulticheckstatus  when 16 then '已审核' end as checkstatus
 from		 ICClassMCRecord1007130 mcr
 right join   ExpoutreqMain  as chuyuntongzhi
 on mcr.fbillid=chuyuntongzhi.finterid
--销售出库单 老单 还未找到方法。 只显示是否审核
union 
select '销售出库单' as billtype,fbillno as billno,finterid as fbillid ,null as fcheckname ,null as checkdirection,null as fcheckdate ,null as fcheckto_name,fchkpassitem as checkstatus
 from vwICBill_8 as xiaoshouchuku
--- 采购申请单
union
select '采购申请单' as billtype,caigoushenqing.fbillno as billno
, fbillid,fcheckname as fcheckname
,case mcr.fcheckdirection when 1 then '启动'  when 2 then '审核'when 4 then '驳回' end as checkdirection
 , mcr.fcheckdate as fcheckdate,fcheckto_name as fcheckto_name
 ,case caigoushenqing.fmulticheckstatus  when 16 then '已审核' end as checkstatus
 from		 ICClassMCRecord1070 mcr
 right join   POrequest  as caigoushenqing
 on mcr.fbillid=caigoushenqing.finterid
--合同应付  已经在合同应收里写好了
--采购订单
union

select '采购订单' as billtype,caigoudingdan.fbillno as billno
, fbillid,fcheckname as fcheckname
,case mcr.fcheckdirection when 1 then '启动'  when 2 then '审核'when 4 then '驳回' end as checkdirection
 , mcr.fcheckdate as fcheckdate,fcheckto_name as fcheckto_name
 ,case caigoudingdan.fmulticheckstatus  when 16 then '已审核' end as checkstatus
 from		 ICClassMCRecord1071 mcr
 right join   POOrder  as caigoudingdan
 on mcr.fbillid=caigoudingdan.finterid
--验货通知单



 order by billno, mcr.fcheckdate
/*support

ICClassMCRecord1071 
--support*/

end
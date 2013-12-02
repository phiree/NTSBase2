--报价单
/*销售出库单审核路线还没有弄清楚
销售发票还没做。
*/
select 
baojiadan.fbillno as billno, fbillid,fcheckname as fcheckname,
case mcr.fcheckdirection when 1 then '启动'  when 2 then '审核'
 when 4 then '驳回' end as checkdirection
 , mcr.fcheckdate as fcheckdate,fcheckto_name as fcheckto_name
 ,case  baojiadan.fmulticheckstatus when 16 then '已审核' end as checkstatus
 from ICClassMCRecord1007006 mcr
 right join PORFQ  as baojiadan
 on mcr.fbillid=baojiadan.finterid
union 
---合同应收---
select hetongyingshou.fcontractno as billno, fbillid,fcheckname as fcheckname,
case mcr.fcheckdirection when 1 then '启动'  when 2 then '审核'
 when 4 then '驳回' end as checkdirection
 , mcr.fcheckdate as fcheckdate,fcheckto_name as fcheckto_name
 ,case hetongyingshou.fmulticheckstatus  when 16 then '已审核' end  as checkstatus
 from ICClassMCRecord1000019 mcr
 right join t_RPContract  as hetongyingshou
 on mcr.fbillid=hetongyingshou.fcontractid


--销售订单
union
select xiaoshoudingdan.fbillno as billno
, fbillid,fcheckname as fcheckname
,case mcr.fcheckdirection when 1 then '启动'  when 2 then '审核'when 4 then '驳回' end as checkdirection
 , mcr.fcheckdate as fcheckdate,fcheckto_name as fcheckto_name
 ,case xiaoshoudingdan.fmulticheckstatus  when 16 then '已审核' end as checkstatus
 from		 ICClassMCRecord1007100 mcr
 right join   seorder  as xiaoshoudingdan
 on mcr.fbillid=xiaoshoudingdan.finterid

union
---出运通知
select chuyuntongzhi.fbillno as billno
, fbillid,fcheckname as fcheckname
,case mcr.fcheckdirection when 1 then '启动'  when 2 then '审核'when 4 then '驳回' end as checkdirection
 , mcr.fcheckdate as fcheckdate,fcheckto_name as fcheckto_name
 ,case chuyuntongzhi.fmulticheckstatus  when 16 then '已审核' end as checkstatus
 from		 ICClassMCRecord1007130 mcr
 right join   ExpoutreqMain  as chuyuntongzhi
 on mcr.fbillid=chuyuntongzhi.finterid
--销售出库单 老单 还未找到方法。 只显示是否审核
union 
select fbillno as billno,finterid as fbillid ,null as fcheckname ,null as checkdirection,null as fcheckdate ,null as fcheckto_name,fchkpassitem as checkstatus
 from vwICBill_8 as xiaoshouchuku
--- 采购申请单
union
select caigoushenqing.fbillno as billno
, fbillid,fcheckname as fcheckname
,case mcr.fcheckdirection when 1 then '启动'  when 2 then '审核'when 4 then '驳回' end as checkdirection
 , mcr.fcheckdate as fcheckdate,fcheckto_name as fcheckto_name
 ,case caigoushenqing.fmulticheckstatus  when 16 then '已审核' end as checkstatus
 from		 ICClassMCRecord1070 mcr
 right join   POrequest  as caigoushenqing
 on mcr.fbillid=caigoushenqing.finterid



 order by billno, mcr.fcheckdate
/*support*/

SELECT FCheckCtlLevel FROM t_MultiCheckOption WHERE FOptionvalue>0 AND  FBilltype=21

/*--support*/


SELECT * FROM ICBillNo 

select FMCContent from ICClassMCTemplate where fid=44

select FMultiCheckStatus from POrequest where FInterID=23 and FTranType=1070
select FControl from ICClassType where fid=1070
select finterid,fbillno,* from POrequest
select * from ICClassMCRecord1007006
select * from ICClassMCRecord1070
if exists(select 1 from sysobjects where name='ICClassMCRecord1070' and xtype='u')
  begin
     select top 1 t1.ftemplateid,t2.FIsRun from ICClassMCRecord1070 t1 
     inner join icclassmctemplate t2 on t1.ftemplateid=t2.fid
     where t1.FBillID=23 order by t1.fid desc
  end
else
     select -1 as ftemplateid,0 as FIsRun 
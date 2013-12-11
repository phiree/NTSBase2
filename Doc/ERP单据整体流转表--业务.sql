set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[ERPService_BillProcess]
as
begin 
/*
	2013-12-11 
 先删除发票, 和收款付款单.
*/
-- icbillno :单据号前缀表
select
  -- distinct
--baojia.*

 '销售报报价单',baojia.fBillNo  
  ,'制单人',yonghu.fname  
 ,'合同应收',hetongyingshou.fContractNo,'合同名称'
,hetongyingshou.fContractName,hetongyingshou.fcontractid  
  ,'外销订单',waixiaodingdan.fbillno  
    ,'----销售分支----'  
  ,'出运通知单',chuyun.fbillno  
  ,'销售出库',xiaoshouchuku.fbillno  
-- ,'销售发票' ,xiaoshoufapiao.fbillno
  --,'收款单' ,shoukuandan.fnumber
  ,'----采购分支----'  
  ,'采购申请单',caigoushenqing.fbillno  
  ,'合同应付',hetongyingfu.fContractNo,'合同名称',hetongyingfu.fContractName  
  ,'采购订单',caigoudingdan.fbillno  

  --,case caigoudingdan.fcancellation when 1 then '已作废' else '' end  
  ,'验货通知单',yanhuotongzhi.fbillno  
  ,'外购入库单',waigouruku.fbillno  
 --  ,'采购发票',caigoufapiao.fbillno  
 -- ,'付款单',fukuandan.fnumber  
  ,'-----流程完成-----'  
 from  
--报价单   
 porfq as  baojia  
     inner join t_user as yonghu  
	 on yonghu.fempid=baojia.fempid  
--合同应收  
left join 
(
-- select distinct fcontractno from t_rpContract
	select hetongyingshoumingxi.*,fcontractno,fcontractname
	from t_rpContract 
		CROSS APPLY(   
		select top 1 fcontractid,fbillno_src
		from t_rpContractEntry  
		where t_rpContractEntry.fcontractid=t_rpContract.fcontractid
		)hetongyingshoumingxi
	) as hetongyingshou 
 on  hetongyingshou.fbillno_src=baojia.fbillNo  
 and hetongyingshou.fcontractno not like '%_000'

--外销订单  
 left join   
(
select waixiaodingdanmingxi.*,fbillno
from seorder
cross apply 
	(
		select top 1 fsourcebillno
		from SeOrderEntry 
		where SeOrderEntry.finterid=seorder.finterid
	)waixiaodingdanmingxi
) as waixiaodingdan
 
 on waixiaodingdan.fsourcebillno=hetongyingshou.fcontractno
----------------销售分支-----------------  
--出运通知  
 left join
(
 select chuyunmingxi.*,fbillno 
 from  expoutreqmain 
 cross apply
	(
	   select top 1 fbillno_src 
       from ExpOutReqEntry
		where finterid= expoutreqmain.finterid
	)chuyunmingxi
) as chuyun 
on chuyun.fbillno_src=waixiaodingdan.fbillno
-- ExpOutReqEntry as chuyunmingxi  
--   on chuyunmingxi.fbillno_src=waixiaodingdan.fbillno  
--  left join ExpoutreqMain as chuyun  
--   on chuyunmingxi.finterid=chuyun.finterid  
--销售出库  
--select distinct fbillno  from  vwICBill_8
--select * from  vwICBill_8
/*

select l.fbilll fsourcebillno,fcontractbillno,forderbillno ,* from icstockbillentry d
inner join icstockbill l 
on d.finterid=l.finterid
*/
left join
(

 select xiaoshouchukumingxi.*,fbillno 
 from  icstockbill 
 cross apply
	(
	   select  top 1 fsourcebillno
       from ICStockBillentry
		where finterid= icstockbill.finterid
	)xiaoshouchukumingxi
) as xiaoshouchuku 
on xiaoshouchuku.fsourcebillno=chuyun.fbillno
--销售发票
/*select * from ICSale 
select * from ICSaleEntry 
 left join
(
 select xiaoshoufapiaomingxi.*,fbillno 
 from  ICSale 
 cross apply
	(
	   select top 1 fcontractbillno
       from ICSaleEntry
		where finterid= ICSale.finterid
	)xiaoshoufapiaomingxi
) as xiaoshoufapiao 
on xiaoshoufapiao.fcontractbillno=hetongyingshou.fcontractno
*/

---收款单  收款单来源有两处:合同应收 和 销售发票.
-- 系统里的收款单 除了保存来源单据,还保存了对应的合同号.
/*select * from t_RP_NewReceiveBill     
select * from t_rp_ARBillOfSH

left join
(
 select shoukuandanmingxi.*,fnumber
 from  t_RP_NewReceiveBill 
 cross apply
	(
	   select top 1 fcontractno 
       from t_rp_ARBillOfSH
		where fbillid= t_RP_NewReceiveBill.fbillid
	)shoukuandanmingxi
) as shoukuandan 
on shoukuandan.fcontractno=hetongyingshou.fcontractno
 */
 /***---------------采购分支-------------**/  
--采购申请  

left join
(
 select caigoushenqingmingxi.*,fbillno 
 from  PORequest 
 cross apply
	(
	   select top 1 fsourcebillno 
       from PORequestEntry
		where finterid= PORequest.finterid
	)caigoushenqingmingxi
) as caigoushenqing 
on caigoushenqing.fsourcebillno=waixiaodingdan.fbillno
 
-- 合同应付  
left join
(
 select hetongyingfumingxi.*,fcontractno,fcontractname
 from  t_rpContract 
 cross apply
	(
	   select top 1 fbillno_src
       from t_rpContractEntry
		where fContractid= t_rpContract.fContractid
	)hetongyingfumingxi
) as hetongyingfu 
on hetongyingfu.fbillno_src=caigoushenqing.fbillno
 
/**采购订单 8s **/  
left join
(
--select * from poorder
 select caigoudingdanmingxi.*,fbillno ,fcancellation
 from  poorder 
 cross apply
	(
	   select top 1 fsourcebillno
       from poorderentry
		where finterid= poorder.finterid
	)caigoudingdanmingxi
) as caigoudingdan 
on caigoudingdan.fsourcebillno=hetongyingfu.fcontractno
and caigoudingdan.fcancellation=0

 --(验货通知单)收料通知  
left join
(
 select yanhuotongzhimingxi.*,fbillno 
 from  poinstock 
 cross apply
	(
	   select  top 1 fsourcebillno
       from POInStockEntry
		where finterid= poinstock.finterid
	)yanhuotongzhimingxi
) as yanhuotongzhi 
on yanhuotongzhi.fsourcebillno=caigoudingdan.fbillno
----   
 --外购入库单  

left join
(
 select waigourukumingxi.*,fbillno 
 from  icstockbill 
 cross apply
	(
	   select  top 1 fsourcebillno
       from ICStockBillentry
		where finterid= icstockbill.finterid
	)waigourukumingxi
) as waigouruku 
on waigouruku.fsourcebillno=yanhuotongzhi.fbillno

-----
 
 --采购发票  
/*
left join
(
 select caigoufapiaomingxi.*,fbillno 
 from  ICPurchase 
 cross apply
	(
	   select top 1 fcontractbillno
       from ICPurchaseEntry
	   where finterid= ICPurchase.finterid
	)caigoufapiaomingxi
) as caigoufapiao 
on caigoufapiao.fcontractbillno=hetongyingfu.fcontractno

  
 --付款单  
left join
(
 select fukuanmingxi.*,fbillid ,fnumber
 from  t_RP_NewReceiveBill 
 cross apply
	(
	   select top 1 fcontractno
       from t_rp_ARBillOfSH
	   where fbillid= t_RP_NewReceiveBill.fbillid
	)fukuanmingxi
) as fukuandan 
on fukuandan.fcontractno=hetongyingfu.fcontractno
*/
--end--
                                                                  
end



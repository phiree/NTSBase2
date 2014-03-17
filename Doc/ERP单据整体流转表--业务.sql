USE [AIS20130703114122]
GO
/****** Object:  StoredProcedure [dbo].[ERPService_BillProcess]    Script Date: 03/11/2014 17:33:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[ERPService_BillProcess]
as
begin 
/**********************************************
	2014-3-11
 返回列名
	2013-12-11 
  删除发票, 和收款付款单.
    2013-12-12
  将业务单据的流程 和 财务单据 分开
  增加采购订单制单人栏

--------Support Scripts---------
  select a.fname,b.fempid,b.* from t_user a ,poorder b
where a.fempid=b.fempid
select * from poorder
select * from t_user  where fuserid=291

*****************************************/
-- icbillno :单据号前缀表
select
  -- distinct
--baojia.*

 baojia.fBillNo as '报价单号',baojia.fdate as '销售报报价单',
  yonghu.fname  as '制单人',
 hetongyingshou.fContractNo as '合同应收',
hetongyingshou.fContractName as '名称',
  waixiaodingdan.fbillno as '外销订单',
    '-销售分支-',  
  chuyun.fbillno  as '出运通知单',
  xiaoshouchuku.fbillno as '销售出库',
  xiaoshouchuku.fdate as '出库日期',
  '-采购分支-',
  caigoushenqing.fbillno as '采购申请单',
  caigoushenqing.fdate as '申请日期',
  hetongyingfu.fContractNo as '合同应付',
  hetongyingfu.fContractName  as '合同名称',
  caigoudingdan.fbillno as '采购订单',
  yonghu2.fname as '采购员',
 yanhuotongzhi.fbillno  as '验货通知单',
 waigouruku.fbillno as '外购入库单',
 waigouruku.fdate as '入库日期'
  
 from  
--报价单   
--select * from porfq
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
		select distinct fcontractid,fbillno_src
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
		select distinct fsourcebillno
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
	   select distinct fbillno_src 
       from ExpOutReqEntry
		where finterid= expoutreqmain.finterid
	)chuyunmingxi
) as chuyun 
on chuyun.fbillno_src=waixiaodingdan.fbillno
 
--销售出库  

left join
(
 select xiaoshouchukumingxi.*,fbillno ,fdate
 from  icstockbill 
 cross apply
	(
	   select  distinct fsourcebillno
       from ICStockBillentry
		where finterid= icstockbill.finterid
	)xiaoshouchukumingxi
) as xiaoshouchuku 
on xiaoshouchuku.fsourcebillno=chuyun.fbillno

--采购申请  

left join
(
 select caigoushenqingmingxi.*,fbillno,fdate
 from  PORequest 
 cross apply
	(
	   select distinct fsourcebillno 
       from  PORequestEntry
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
	   select distinct fbillno_src
       from t_rpContractEntry
		where fContractid= t_rpContract.fContractid
	)hetongyingfumingxi
) as hetongyingfu 
on hetongyingfu.fbillno_src=caigoushenqing.fbillno
 
/**采购订单 8s **/  
left join
(
 select caigoudingdanmingxi.*,fbillno ,fcancellation,fempid
 from  poorder 
 cross apply
	(-- select * from poorder
-- select * from t_user
	   select distinct fsourcebillno
       from poorderentry a
		where finterid= poorder.finterid
        
	)caigoudingdanmingxi

) as caigoudingdan 
on caigoudingdan.fsourcebillno=hetongyingfu.fcontractno
and caigoudingdan.fcancellation=0
left join t_user yonghu2
on yonghu2.fempid=caigoudingdan.fempid


 --(验货通知单)收料通知
left join
(
 select yanhuotongzhimingxi.*,fbillno 
 from  poinstock 
 cross apply
	(
	   select  distinct fsourcebillno
       from POInStockEntry
		where finterid= poinstock.finterid
	)yanhuotongzhimingxi
) as yanhuotongzhi 
on yanhuotongzhi.fsourcebillno=caigoudingdan.fbillno
 
--外购入库单  

left join
(
 select waigourukumingxi.*,fbillno ,fdate
 from  icstockbill 
 cross apply
	(
	   select  distinct fsourcebillno
       from ICStockBillentry
		where finterid= icstockbill.finterid
	)waigourukumingxi
) as waigouruku 
on waigouruku.fsourcebillno=yanhuotongzhi.fbillno

order by baojia.fBillNo
end



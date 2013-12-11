set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[ERPService_BillProcess_Finance]
as
begin 
/*
财务单据流程

*/

select
  -- distinct
--baojia.* 
  '合同',hetong.fContractNo
 ,'发票' ,fapiao.fbillno
 ,'收款/付款单' ,kuan.fnumber


 from  
--合同  
 t_rpContract as  hetong  
-- 收款 付款
left join
(
 select kuanmingxi.*,fnumber
 from  t_RP_NewReceiveBill 
 cross apply
	(
	   select top 1 fcontractno 
       from t_rp_ARBillOfSH
		where fbillid= t_RP_NewReceiveBill.fbillid
	)kuanmingxi
) as kuan 
on kuan.fcontractno=hetong.fcontractno 


--发票
/*select * from ICSale 
select * from ICSaleEntry */
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
 union 
 select caigoufapiaomingxi.*,fbillno 
 from  ICPurchase 
 cross apply
	(
	   select top 1 fcontractbillno
       from ICPurchaseEntry
	   where finterid= ICPurchase.finterid
	)caigoufapiaomingxi

) as fapiao 

on fapiao.fcontractbillno=hetong.fcontractno

where  hetong.fcontractno not like '%_000'
                                                   
end



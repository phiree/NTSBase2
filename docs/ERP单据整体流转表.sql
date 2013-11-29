select distinct 
			'销售报报价单',baojia.fBillNo,baojia.FInterID
			,'制单人',yonghu.fname
		,'合同应收',hetongyingshou.fContractNo,hetongyingshou.fcontractid
		,'外销订单',waixiaodingdan.fbillno,waixiaodingdan.FInterID
		,'----销售分支----'
		,'出运通知单',chuyun.fbillno,chuyun.finterid
		,'销售出库',xiaoshouchuku.fbillno,xiaoshouchuku.finterid
		,'销售发票'
		,'收款单'
		,'----采购分支----'
		,'采购申请单',caigoushenqing.fbillno,caigoushenqing.finterid
		,'合同应付',hetongyingfu.fContractNo
		,'采购订单',caigoudingdan.fbillno
		,case caigoudingdan.fcancellation when 1 then '已作废' else '' end
		,'验货通知单',yanhuotongzhi.fbillno
		,'外购入库单',waigouruku.fbillno
		,'采购发票',caigoufapiao.fbillno
		,'付款单',fukuandan.fnumber
		,'-----流程完成-----'
	from
--报价单 
	porfq as  baojia
   		left join t_user as yonghu
		on yonghu.fempid=baojia.fempid
--合同应收
	left join 
		 t_rpContractEntry as hetongyingshoumingxi
			on   hetongyingshoumingxi.fbillno_src=baojia.fbillNo
		left join t_rpContract as hetongyingshou 
			on hetongyingshou.fContractid=hetongyingshoumingxi.fcontractid
--外销订单
	left join 
		SeOrderEntry as waixiaodingdanmingxi
			on waixiaodingdanmingxi.fsourcebillno=hetongyingshou.fcontractno
		left join seorder as waixiaodingdan
			on waixiaodingdan.finterId=waixiaodingdanmingxi.finterid
----------------销售分支-----------------
--出运通知
	left join ExpOutReqEntry as chuyunmingxi
			on chuyunmingxi.fbillno_src=waixiaodingdan.fbillno
		left join ExpoutreqMain as chuyun
			on chuyunmingxi.finterid=chuyun.finterid
--销售出库
    left join vwICBill_8  as xiaoshouchuku
			on xiaoshouchuku.fsourcebillno=chuyun.fbillno
 /***---------------采购分支-------------**/
--采购申请
	left join PORequestEntry as caigoushenqingmingxi
			on caigoushenqingmingxi.fsourcebillno=waixiaodingdan.fbillno
		left join PORequest caigoushenqing
			on caigoushenqingmingxi.finterid=caigoushenqing.finterid
	left join 
		t_rpContractEntry as hetongyingfumingxi
			on   hetongyingfumingxi.fbillno_src=caigoushenqing.fbillNo
		left join t_rpContract as hetongyingfu 
			on hetongyingfu.fContractid=hetongyingfumingxi.fcontractid
/**采购订单**/
	left join poorderentry as caigoudingdanmingxi
			on caigoudingdanmingxi.fsourcebillno=hetongyingfu.fcontractno
		left join  poorder as caigoudingdan
			on caigoudingdan.finterid=caigoudingdanmingxi.finterid
	--(验货通知单)收料通知		
	left join POInStockEntry as yanhuotongzhimingxi
		on yanhuotongzhimingxi.fsourcebillno=caigoudingdan.fbillno
		left join poinstock as yanhuotongzhi
			on yanhuotongzhi.finterid=yanhuotongzhimingxi.finterid
	--外购入库单
	left join ICStockBillentry  as waigourukumingxi
		on waigourukumingxi.fsourcebillno=yanhuotongzhi.fbillno
		left join icstockbill as waigouruku
			on waigouruku.finterid=waigourukumingxi.finterid
	--采购发票
	left join ICPurchaseEntry as caigoufapiaomingxi
		on caigoufapiaomingxi.fsourcebillno=waigouruku.fbillno
		left join ICPurchase as caigoufapiao
			on caigoufapiao.finterid=caigoufapiaomingxi.finterid
	--付款单
	left join t_rp_ARBillOfSH as fukuanmingxi
		on fukuanmingxi.fbillno_src=caigoufapiao.fbillno
		left join t_RP_NewReceiveBill as fukuandan
			on fukuanmingxi.fbillid=fukuandan.fbillid
	/***采购财务分支**/
		
/*每一个单据的详细审核流程（不准确）

select * 
--fbillid,fcheckname,fcheckdate,fcheckto_name
 from ICClassMCRecord1007006 order by fbillid,fcheckdate
*/                                                                                                                                                                                                                                                                                                                                
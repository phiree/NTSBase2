select distinct 
			'销售报报价单',baojia.fBillNo
			,'制单人',yonghu.fname
		,'合同应收',hetongyingshou.fContractNo
		,'外销订单',waixiaodingdan.fbillno
		,'----销售分支----'
		,'出运通知单',chuyun.fbillno
		,'销售出库',xiaoshouchuku.fbillno
		,'----采购分支----'
		,'采购申请单',caigoushenqing.fbillno
		,'合同应付',hetongyingfu.fContractNo
		,'采购订单',caigoudingdan.fbillno
		,'验货通知单',yanhuotongzhi.fbillno
		,'外购入库单',waigouruku.fbillno
		,'----采购财务分支----'

		 from porfq as  baojia
   	left join t_user as yonghu
		on yonghu.fempid=baojia.fempid
	left join 
		 t_rpContractEntry as hetongyingshoumingxi
			on   hetongyingshoumingxi.fbillno_src=baojia.fbillNo
		left join t_rpContract as hetongyingshou 
			on hetongyingshou.fContractid=hetongyingshoumingxi.fcontractid

	left join 
		SeOrderEntry as waixiaodingdanmingxi
			on waixiaodingdanmingxi.fsourcebillno=hetongyingshou.fcontractno
		left join seorder as waixiaodingdan
			on waixiaodingdan.finterId=waixiaodingdanmingxi.finterid
	left join ExpOutReqEntry as chuyunmingxi
			on chuyunmingxi.fbillno_src=waixiaodingdan.fbillno
		left join ExpoutreqMain as chuyun
			on chuyunmingxi.finterid=chuyun.finterid
    left join vwICBill_8  as xiaoshouchuku
			on xiaoshouchuku.fsourcebillno=chuyun.fbillno
   /***采购分支**/
	left join PORequestEntry as caigoushenqingmingxi
			on caigoushenqingmingxi.fsourcebillno=waixiaodingdan.fbillno
		left join PORequest caigoushenqing
			on caigoushenqingmingxi.finterid=caigoushenqing.finterid
	left join 
		t_rpContractEntry as hetongyingfumingxi
			on   hetongyingfumingxi.fbillno_src=caigoushenqing.fbillNo
		left join t_rpContract as hetongyingfu 
			on hetongyingfu.fContractid=hetongyingfumingxi.fcontractid
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
	/***采购财务分支**/
		
/**/                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                

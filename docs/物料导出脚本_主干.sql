 SELECT 
-- 
p.ntscode AS 代码,
-- 
CASE WHEN  plZh.Name IS NULL THEN  pl.name ELSE plZh.Name END AS 名称,
'TRUE' AS 明细,
'' AS 审核人_FName, 
-- 
CASE WHEN  plZh.Name IS NULL THEN  pl.name ELSE plZh.Name END  AS 物料全名,
'' AS 助记码,
LEFT(CASE WHEN plZH.ProductParameters IS NULL THEN pl.ProductParameters   ELSE plZH.ProductParameters END ,128) AS 规格型号,
'' AS 辅助属性类别_FName,
'' AS 辅助属性类别_FNumber,
'外购' AS 物料属性_FName,
'主推商品' AS 物料分类_FName,
-- 
'general' AS 计量单位组_FName,
--  
'pcs' AS 基本计量单位_FName,
 -- 
'general' AS 基本计量单位_FGroupName,
-- 
'pcs' AS 采购计量单位_FName,
-- 
'general' AS 采购计量单位_FGroupName,
'pcs' AS 销售计量单位_FName,
'general' AS 销售计量单位_FGroupName,
'pcs' AS 生产计量单位_FName,
'general' AS 生产计量单位_FGroupName,
'pcs' AS 库存计量单位_FName,
'general' AS 库存计量单位_FGroupName,
'' AS 辅助计量单位_FName,
'' AS 辅助计量单位_FGroupName,
'0' AS 辅助计量单位换算率,
'NTS仓库' AS 默认仓库_FName,
'01' AS 默认仓库_FNumber,
'仓位一' AS 默认仓位_FName,
'仓位组一' AS 默认仓位_FGroupName,
s.name AS 来源_FName,
s.code AS 来源_FNumber,
'4' AS 数量精度,
'1' AS 最低存量,
'11000' AS 最高存量,
'2' AS 安全库存数量,
'使用' AS 使用状态_FName,
'FALSE' AS 是否为设备,
'' AS 设备编码,
'FALSE' AS 是否为备件,
'' AS 批准文号,
'' AS 别名,
'0' AS 物料对应特性,
'*' AS 默认待检仓库_FName,
'*' AS 默认待检仓库_FNumber,
'*' AS 默认待检仓位_FName,
'*' AS 默认待检仓位_FGroupName,
p.moneyType AS 币别_FName,
p.moneyType AS 币别_FNumber,
'0' AS 采购最高价,
'*' AS 采购最高价币别_FName,
'*' AS 采购最高价币别_FNumber,
'0' AS 委外加工最高价,
'*' AS 委外加工最高价币别_FName, 
'*' AS 委外加工最高价币别_FNumber,
'0' AS 销售最低价,
'*' AS 销售最低价币别_FName,
'*' AS 销售最低价币别_FNumber,
'FALSE' AS 是否销售,
'*' AS 采购负责人_FName,
'*' AS 采购负责人_FNumber,
'0' AS 毛利率,
--  
PriceOfFactory AS 采购单价,
'0' AS 销售单价,
'FALSE' AS 是否农林计税,
'FALSE' AS 是否进行保质期管理,
'0' AS 保质期天,
'FALSE' AS 是否需要库龄管理,
'FALSE' AS 是否采用业务批次管理,
'FALSE' AS 是否需要进行订补货计划的运算,
'0' AS 失效提前期天,
'' AS 盘点周期单位_FName,
'0' AS 盘点周期,
'0' AS 每周月第天,
'' AS 上次盘点日期,
'0' AS 外购超收比例,
'0' AS 外购欠收比例,
'0' AS 销售超交比例,
'0' AS 销售欠交比例,
'0' AS 完工超收比例,
'0' AS 完工欠收比例,
'0' AS 领料超收比例,
'0' AS 领料欠收比例,
'加权平均法' AS 计价方法_FName,
'0' AS 计划单价,
'2' AS 单价精度,
'1001' AS 存货科目代码_FNumber,
'1001' AS 销售收入科目代码_FNumber,
'1001' AS 销售成本科目代码_FNumber,
'' AS 成本差异科目代码_FNumber,
'' AS 代管物资科目_FNumber,
'' AS 税目代码_FName,
'0' AS 税率,
'*' AS 成本项目_FName,
'*' AS 成本项目_FNumber,
'FALSE' AS 是否进行序列号管理,
'FALSE' AS 参与结转式成本还原,
'' AS 备注,
'物料需求计划(MRP)' AS 计划策略_FName,
'MTS计划模式' AS 计划模式_FName,
'批对批(LFL)' AS 订货策略_FName,
'30' AS 固定提前期,
'0' AS 变动提前期,
'0' AS 累计提前期,
'1' AS 订货间隔期天,
'20' AS 最小订货量,
'9999' AS 最大订货量,
'0' AS 批量增量,
'FALSE' AS 设置为固定再订货点,
'0' AS 再订货点,
'0' AS 固定经济批量,
'1' AS 变动提前期批量,
'0' AS 批量拆分间隔天数,
'0' AS 拆分批量,
'0' AS 需求时界天,
'0' AS 计划时界天,
'' AS 默认工艺路线_FInterID,
'' AS 默认工艺路线_FRoutingName,
'' AS 默认生产类型_FName,
'' AS 默认生产类型_FNumber,
'*' AS 生产负责人_FName,
'*' AS 生产负责人_FNumber,
'*' AS 计划员_FName,
'*' AS 计划员_FNumber,
'FALSE' AS 是否倒冲,
'*' AS 倒冲仓库_FName,
'*' AS 倒冲仓库_FNumber,
'*' AS 倒冲仓位_FName,
'*' AS 倒冲仓位_FGroupName,
'FALSE' AS 投料自动取整,
'0' AS 日消耗量,
'TRUE' AS MRP计算是否合并需求,
'FALSE' AS MRP计算是否产生采购申请,
'ERP' AS 控制类型_FName,
'' AS 控制策略_FName,
'' AS 容器名称,
'1' AS 看板容量,
'' AS 图号,
'FALSE' AS 是否关键件,
'0' AS 毛重,
'0' AS 净重,
'' AS 重量单位_FName,
'' AS 重量单位_FGroupName,
'0' AS 长度,
'0' AS 宽度,
'0' AS 高度,
'0' AS 体积,
'' AS 长度单位_FName,
'' AS 长度单位_FGroupName,
'' AS 版本号,
'0' AS 单位标准成本,
'0' AS 附加费率,
'' AS 附加费所属成本项目_FNumber,
'' AS 成本BOM_FBOMNumber,
'' AS 成本工艺路线_FInterID,
'' AS 成本工艺路线_FRoutingName,
'1' AS 标准加工批量,
'0' AS 单位标准工时小时,
'0' AS 标准工资率,
'0' AS 变动制造费用分配率,
'0' AS 单位标准固定制造费用金额,
'0' AS 单位委外加工费,
'' AS 委外加工费所属成本项目_FNumber,
'0' AS 单位计件工资,
'' AS 采购订单差异科目代码_FNumber,
'' AS 采购发票差异科目代码_FNumber,
'' AS 材料成本差异科目代码_FNumber,
'' AS 加工费差异科目代码_FNumber,
'' AS 废品损失科目代码_FNumber,
'' AS 标准成本调整差异科目代码_FNumber,
'免检' AS 采购检验方式_FName,
'免检' AS 产品检验方式_FName,
'免检' AS 委外加工检验方式_FName,
'免检' AS 发货检验方式_FName,
'免检' AS 退货检验方式_FName,
'免检' AS 库存检验方式_FName,
'免检' AS 其他检验方式_FName,
'' AS 抽样标准致命_FName,
'' AS 抽样标准致命_FNumber,
'' AS 抽样标准严重_FName,
'' AS 抽样标准严重_FNumber,
'' AS 抽样标准轻微_FName,
'' AS 抽样标准轻微_FNumber,
'0' AS 库存检验周期天,
'0' AS 库存周期检验预警提前期天,
'' AS 检验方案_FInterID,
'' AS 检验方案_FBrNo,
'*' AS 检验员_FName,
'*' AS 检验员_FNumber,
CASE WHEN pl.Name IS NULL THEN plZh.Name ELSE pl.Name END AS 英文名称,
LEFT(CASE WHEN pl.ProductParameters IS NULL THEN plZh.ProductParameters ELSE pl.ProductParameters END,128) AS 英文规格,
'' AS HS编码_FHSCode,
'' AS HS编码_FNumber,
'0' AS 外销税率,
'' AS HS第一法定单位,
'' AS HS第二法定单位,
'0' AS 进口关税率,
'0' AS 进口消费税率,
'0' AS HS第一法定单位换算率,
'0' AS HS第二法定单位换算率,
'FALSE' AS 是否保税监管,
'' AS 物料监管类型_FName,
'' AS 物料监管类型_FNumber,
'0' AS 长度精度,
'0' AS 体积精度,
'0' AS 重量精度,
'FALSE' AS 启用服务,
'FALSE' AS 生成产品档案,
'FALSE' AS 维修件,
'0' AS 保修期限（月）,
'0' AS 使用寿命（月）,

p.modelnumber AS 物料型号,
'' AS 收税类型,
'' AS 描述卖点,
'0' AS FOB价,

'0' AS 控制,
'0' AS 是否禁用,
'{C81E92A1-3B20-4E49-B904-299B1B412FC8}' AS 全球唯一标识内码

FROM product  p
INNER JOIN supplier s ON p.SupplierCode=s.Code
LEFT JOIN 
 productlanguage pl
 ON p.id=pl.Product_id AND pl.Language="en"
LEFT JOIN productlanguage plZh
 ON plZh.Product_id=p.Id AND plZh.Language="zh"
 WHERE (pl.Name IS NOT NULL OR plZh.Name IS NOT NULL)
 

/*
select left(pl.productparameters,255) as pp,
length(left(pl.productparameters,255))
,substring(pl.productparameters,1,255)
,length(substr(pl.productparameters,1,255))
,char_length(left(pl.productparameters,255))
,char_length(pl.productparameters)  from product p,productlanguage pl 
where p.id=pl.product_id
order by char_length(pp) desc
limit 100
CHARACTER SET utf-8
where   p.ntscode='06.005.0013400009'

select * from productlanguage where product_id='ff3681a8-ba09-4b84-afd1-a1dd00e71738' order by product_id 

select pl.* from product p
left join productlanguage pl
on p.id=pl.product_id
where pl.name is null
order by pl.name
select * from product where ntscode='06.005.0013400009'

 LIMIT 1
 
  SELECT COUNT(*) FROM product -- 19555
 select count(*) from productlanguage where language="en" ;-- 19555
  SELECT COUNT(*) FROM productlanguage WHERE LANGUAGE="zh" ;-- 19555

select s.name,p.NTSCode, case when  pl.Name is null  then pl2.name  end as plname
	,CASE WHEN  pl2.Name IS NULL  THEN pl.name ELSE pl2.Name END AS pl2name,pl2.name
	from product p
	inner join supplier s
		on s.code=p.suppliercode
	inner join  productlanguage pl
	on pl.Language="en" and pl.Product_id=p.Id 
	left join productlanguage pl2
 on p.id=pl2.product_id 
and  pl2.language="zh"
where p.suppliercode=s.code
	
	limit 10
	
	select * from productlanguage 
	
	select * from productlanguage 
	where language="en" and (
	length(ProductDescription) != character_length(ProductDescription)
	or 	LENGTH(ProductParameters) != CHARACTER_LENGTH(ProductParameters)
	OR 	LENGTH(memo) != CHARACTER_LENGTH(memo) )
	
	select LENGTH(null) != CHARACTER_LENGTH(null) 
	select left("汉字a",2),length(left("汉字a",2)),char_length(left("汉字a",2)),bit_length("汉字a"),bit_length("a")
	select mb_substr("aaa")
	*/
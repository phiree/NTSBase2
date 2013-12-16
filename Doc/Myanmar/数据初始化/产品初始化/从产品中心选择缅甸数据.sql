SELECT 
ntscode AS CODE
,NAME AS NAME
, Modelnumber AS Model -- 规格型号
,pl.Unit AS Unit
,productcode AS barcode
,replace(categorycode,'.','') AS goodSortCode
,'' AS colorgroupcode
,'' AS sex
,TaxRate AS taxrate
,'' AS authCode -- 批准文号
,0 AS RetailPrice
,0 AS WholesalePrice -- 批发价
,0 AS memberprice -- 会员价
,0 AS ReferenceCost -- 参考成本
,pl.placeoforigin AS productarea -- 产地
,'001' AS suppliercode -- 供应商编码 只有一个 nts中国
,NULL AS SizeGroupCode -- 尺码组编码
,NULL AS BrandCode -- 品牌编码
,NULL AS memo
,NULL AS DrawingNumber -- 图纸编号
  FROM product p 
INNER JOIN productlanguage pl
ON p.id=pl.product_id
AND pl.Language='en'
order by p.NTSCode
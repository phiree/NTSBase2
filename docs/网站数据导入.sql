INSERT INTO  magento17.data_import 
        (sku, 
	NAME, 
	specification, 
	price, 
	special_price, 
	manufacturer, 
	model, 
	category_ids, 
	short_description, 
	description, 
	meta_title, 
	meta_keyword, 
	meta_description, 
	image, 
	small_image, 
	thumbnail, 
	is_in_stock, 
	qty, 
	STATUS, 
	tax_class_id, 
	visibility, 
	gallery, 
	sort_order, 
	store, 
	websites, 
	TYPE, 
	attribute_set, 
	weight)

SELECT p.ntscode AS sku
,l.name -- 2
,l.ProductParameters   -- 3
,REPLACE(REPLACE(p.PriceOfFactory,'гд',''),',','')  -- 4
,p.PriceOfFactory
,s.englishname
,p.modelnumber
 ,CONCAT('42,',m2.cateid_website,',',m1.cateid_website)
, l.ProductDescription
, l.ProductDescription
,'' -- seo
,''
,''
,CONCAT('/',i.ImageName)
,CONCAT('/',i.ImageName)
,CONCAT('/',i.ImageName)

,1,10000,1,0,'Catalog,Search'
,CONCAT('/',i.ImageName)
,255
,'default'
,'asia'
,'simple'
,'default'
,0
FROM   ntsbase2.product p 
      ,ntsbase2.productlanguage l
      ,CategoryMap m1
      ,CategoryMap m2
      ,ntsbase2.supplier s
      ,ntsbase2.productimage i
WHERE  l.language="en"
	AND l.product_id=p.id

	AND  p.categorycode=m1.cateid_ntsbase
	AND LEFT(p.categorycode,2)=m2.cateid_ntsbase
        AND p.suppliercode=s.code
        AND p.id=i.product_id
	ORDER BY p.id 
		
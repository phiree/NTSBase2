INSERT INTO  magento17.data_import 
        (sku, -- 1
NAME,            -- 2
	specification,-- 3 
	price,  -- 4
	special_price, -- 5 
	manufacturer, -- 6
	model,   -- 7 
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
	weight,
	parameter)

	
	
SELECT DISTINCT p.ntscode AS sku
,pa.NameForWeb  -- 2
 ,CONCAT(pa.Specification,'<br/>', pa.ProductDescription) -- specification
,REPLACE(REPLACE(p.PriceOfFactory,'£¤',''),',','')  -- 4
,p.PriceOfFactory
,s.englishname
,p.modelnumber
 ,CONCAT('42,',m2.cateid_website,',',m1.cateid_website)
, l.ProductDescription
, ''         -- description
,'' -- seo
,''
,''
,CONCAT('/', p.ntscode,'.jpg')
,CONCAT('/', p.ntscode,'.jpg')
,CONCAT('/',p.ntscode,'.jpg')
/* ÐÍºÅÃû³Æ
,CONCAT('/', i.ImageName)
,CONCAT('/', i.ImageName)
,CONCAT('/',i.ImageName)
*/

,1,10000,1,0,'Catalog,Search'
,CONCAT('/',p.ntscode,'.jpg')
,255
,'default'
,'asia'
,'simple'
,'default'
,0
 ,CONCAT( pa.Parameter,';',pa.Material)  -- 3
FROM   ntsbase2.product p 
  RIGHT JOIN  ntsbase2.product_asia pa
	ON pa.NTSCODE=p.NTSCode AND pa.tag='tina20131220'
	
	
   INNER JOIN  ntsbase2.productlanguage l
	ON p.Id=l.Product_id  AND l.language='en'
   RIGHT JOIN CategoryMap m1
        ON p.categorycode=m1.cateid_ntsbase
 RIGHT JOIN CategoryMap m2
        ON LEFT(p.categorycode,2)=m2.cateid_ntsbase
    
   INNER JOIN ntsbase2.supplier s
      ON p.suppliercode=s.code
      
    INNER JOIN ntsbase2.productimage i
        ON p.id=i.product_id
        
       
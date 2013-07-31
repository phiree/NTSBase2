SELECT * FROM product p WHERE modelnumber IN 
(
'bp-227c-1',
'bp-227t-1',
'bp-b28-1',
'bp-bc32-1',
'bp-tv30-1',
'bp-c29-1',
'bp-t31-1',
'bp-m33-1'
)

DELETE pimage
-- select p.id 
FROM  productimage pimage,product p
WHERE  pimage.Product_id=p.id 
AND p.modelnumber IN (
'bp-227c-1',
'bp-227t-1',
'bp-b28-1',
'bp-bc32-1',
'bp-tv30-1',
'bp-c29-1',
'bp-t31-1',
'bp-m33-1'
)

DELETE pl
-- select p.id 
FROM productlanguage pl,product p
WHERE pl.Product_id=p.id 
AND p.modelnumber IN (
'bp-227c-1',
'bp-227t-1',
'bp-b28-1',
'bp-bc32-1',
'bp-tv30-1',
'bp-c29-1',
'bp-t31-1',
'bp-m33-1'
)


DELETE  
-- select * 
FROM product WHERE modelnumber IN (
'bp-227c',
'bp-227t-2',
'bp-b28-2',
'bp-bc32-2',
'bp-tv30-2',
'bp-c29-2',
'bp-t31-2',
'bp-m33-2'
)

UPDATE product SET modelnumber=SUBSTRING(modelnumber,1,LENGTH(modelnumber)-2)
-- select * from product  
 WHERE modelnumber IN
(
'bp-227c-2',
'bp-227t-2',
'bp-b28-2',
'bp-bc32-2',
'bp-tv30-2',
'bp-c29-2',
'bp-t31-2',
'bp-m33-2'
)
 
  AND suppliercode='00085'
 



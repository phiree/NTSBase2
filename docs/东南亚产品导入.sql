SELECT CONCAT(p.NTSCode,'---', pi.ImageName)
-- SUBSTRING( pi.ImageName,1,length(pi.ImageName)-4) )-- substring(pi.ImageName, )
FROM ntsbase2.product p
,ntsbase2.productimage PI
,ntsbase2.product_asia pa
WHERE pi.Product_id=p.Id
AND pa.NTSCODE=p.NTSCode


SELECT SUBSTRING_INDEX('http://www.example.com/dev/archive/examples/test.htm','/',-1)
SELECT SUBSTRING( 'aserearewrewr.jpg',1,LOCATE('.','aserearewrewr.jpg')-1)

SELECT LENGTH('aserearewrewr.jpg')- LOCATE('.','aserearewrewr.jpg')

SELECT SUBSTRING_INDEX('T2.005MP__00028__c2b749ab-2996-45f1-9b04-4d7b8bc8e6d2.jpg', '.', 2)      

SELECT REVERSE(LEFT(REVERSE('T2.005MP__00028__c2b749ab-2996-45f1-9b04-4d7b8bc8e6d2.jpg')
,INSTR(REVERSE('T2.005MP__00028__c2b749ab-2996-45f1-9b04-4d7b8bc8e6d2.jpg'),'.')))
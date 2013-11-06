


SELECT pl.Name,pl.Unit,pl.ProductParameters,pl.PlaceOfOrigin,pl.PlaceOfDelivery,pl.ProductDescription
	,p.NTSCode,p.SupplierCode,p.ModelNumber
 FROM product p
	LEFT JOIN temp_producttoimport tp
	ON p.NTSCode=tp.ntscode
	INNER JOIN productlanguage pl
	ON pl.Product_id=p.Id AND pl.Language="en"
	WHERE tp.ntscode IS NULL
UNION SELECT  pl.Name,pl.Unit,pl.ProductParameters,pl.PlaceOfOrigin,pl.PlaceOfDelivery,pl.ProductDescription
,p.NTSCode,p.SupplierCode,p.ModelNumber  FROM product p
	INNER JOIN productlanguage pl
	ON pl.Product_id=p.Id AND pl.Language="en"
	WHERE p.SupplierCode IN (
		"00264",
"00262",
"00260",
"00250",
"00248",
"00245",
"00244",
"00239",
"00235",
"00234",
"00232",
"00215",
"00213",
"00211",
"00209",
"00197",
"00196",
"00195",
"00194",
"00193",
"00189",
"00187",
"00185",
"00184",
"00180",
"00162",
"00161",
"00158",
"00154",
"00151",
"00150",
"00148",
"00146",
"00144",
"00142",
"00140",
"00139",
"00138",
"00134",
"00132",
"00129",
"00128",
"00127",
"00124",
"00123",
"00121",
"00119",
"00118",
"00114",
"00113",
"00095",
"00068",
"00067",
"00066",
"00064",
"00061",
"00060",
"00059",
"00052",
"00048",
"00047",
"00045",
"00037"
)

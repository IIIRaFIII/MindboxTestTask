SELECT P.name as product,
       C.name as category 
FROM Products P 
LEFT JOIN Products_Category PC on P.id = PC.product_id 
LEFT JOIN Category C on C.id = PC.category_id
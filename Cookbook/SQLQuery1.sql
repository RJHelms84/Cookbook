SELECT * FROM Recipe

select * from Ingredient

select a.Name from Ingredient a
inner join RecipeIngredient b on a.Id = b.IngredientId
where b.RecipeId = 1;

UPDATE Recipe
SET name = 'Salad'
WHERE Id = 1;

insert into Recipe
values ('Salad New', 50, 'do this then dat yah');

delete from Recipe
where Id = 3;
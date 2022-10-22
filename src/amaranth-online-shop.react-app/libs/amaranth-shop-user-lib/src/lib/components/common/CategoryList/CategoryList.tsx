import { Box, Card } from "@mui/material";
import { useEffect, useState } from "react"
import { productCategoriesUri } from "../../../constants";
import { ProductCategoryDto } from "../../../types";

export const CategoryList = () => {
  const [productCategories, setProductCategories] = useState<Array<ProductCategoryDto>>([]);

  const fetchProductCategories = () => {
    fetch(productCategoriesUri, {
      method: "GET"
    })
      .then((res) => res.json())
      .then((res) => setProductCategories(res))
      .catch((e) => console.log(e));
  }
  useEffect(() => {
    fetchProductCategories()
  }, [])

  return (
    <Box>
      {productCategories.map((productCategory) => (
        <Card
          variant="outlined"
          key={productCategory.id}
        >
          {productCategory.name}
        </Card>
      ))}
    </Box>
  )
}

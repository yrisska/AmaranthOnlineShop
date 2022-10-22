import { Box, Card, CircularProgress, Pagination } from '@mui/material'
import { useEffect, useState } from 'react'
import { getPagedProducts } from '../../../services';
import { ProductPagedQuery, ProductPagedResult } from '../../../types';



const ProductList = () => {

  const [productPagedQuery, setProductPagedQuery] = useState<ProductPagedQuery>({ pageSize: "3" });
  const [pagedProducts, setPagedProducts] = useState<ProductPagedResult | null>(null);

  useEffect(() => {
    fetchPagedProducts();
  }, [productPagedQuery])

  const fetchPagedProducts = async () => {
    try {
      const fetchedPagedProducts = await getPagedProducts(productPagedQuery);

      if (fetchedPagedProducts) {
        setPagedProducts(fetchedPagedProducts);
      }
    } catch (error) {
      console.log(error);
    }
  }

  const handlePageChange = (event: React.ChangeEvent<unknown>, page: number) => {
    setProductPagedQuery({ ...productPagedQuery, pageIndex: '' + page })
  }

  return (
    <Box>
      {
        pagedProducts ?
          <Box>
            {pagedProducts.items.map(product =>
              <Card
                variant="outlined"
                key={product.id}
              >
                {product.name + " - " + product.price + "$"}
              </Card>
            )}
            <Pagination
              page={pagedProducts.pageIndex}
              count={pagedProducts.totalPages}
              onChange={handlePageChange}
            />
          </Box>
          :
          <Box
            component="div"
            display="flex"
            justifyContent="center"
            alignItems="center"
            height="100%"
          >
            <CircularProgress />
          </Box>
      }
    </Box>
  )
}

export default ProductList
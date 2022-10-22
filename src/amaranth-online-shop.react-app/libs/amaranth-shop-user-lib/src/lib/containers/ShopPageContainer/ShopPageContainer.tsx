import ProductList from '../../components/common/ProductList/ProductList'
import { PageLayout } from '../../layout'
import { AppRouteEnum } from '../../types'

export const ShopPageContainer = () => {
  return (
    <PageLayout
      currentPage={AppRouteEnum.SHOP}
    >
      <ProductList />
    </PageLayout>
  )
}

export default ShopPageContainer
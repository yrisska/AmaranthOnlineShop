import { CategoryList } from '../../components/common/CategoryList/CategoryList'
import { PageLayout } from '../../layout'
import { AppRouteEnum } from '../../types'

export const HomaPageContainer = () => {
  return (
    <PageLayout
        currentPage={AppRouteEnum.HOME}
    >
        <CategoryList />
    </PageLayout>
  )
}

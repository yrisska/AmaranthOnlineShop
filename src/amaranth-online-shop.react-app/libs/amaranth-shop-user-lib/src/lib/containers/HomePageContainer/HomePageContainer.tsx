import { CategoryList } from "../../components/common/CategoryList/CategoryList";
import { PageLayout } from "../../layout";
import { AppRouteEnum } from "../../types";

export const HomePageContainer = () => {
  return (
    <PageLayout
      currentPage={AppRouteEnum.HOME}
    >
      <CategoryList />
    </PageLayout>
  );
};

export default HomePageContainer;
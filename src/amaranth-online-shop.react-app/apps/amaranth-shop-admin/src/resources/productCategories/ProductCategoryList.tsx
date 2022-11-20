import { useMediaQuery, useTheme } from "@mui/material";
import { Datagrid, ImageField, List, SimpleList, TextField, TextInput } from "react-admin";

const productCategoriesFilters = [
  <TextInput
    key={1}
    source="name"
    label="Search"
    alwaysOn
  />
];

const ProductCategoryList = () => {

  const theme = useTheme();
  const isSmall = useMediaQuery(theme.breakpoints.down("sm"));

  return (
    <List
      filters={productCategoriesFilters}
      title="Categories"
    >
      {isSmall ? (
        <SimpleList
          primaryText={record => record.name}
        />
      ) : (
        <Datagrid rowClick="edit">
          <TextField source="id" />
          <TextField source="name" />
          <ImageField
            source="imageUri"
            label="Image"
            sortable={false}
          />
        </Datagrid>
      )}
    </List>
  );
};
export default ProductCategoryList;
import { useMediaQuery, useTheme } from "@mui/material";
import { Datagrid, ImageField, List, NumberField, ReferenceField, ReferenceInput, SimpleList, TextField, TextInput } from "react-admin";

const productFilters = [
  <TextInput
    key={1}
    source="name"
    label="Search"
    alwaysOn
  />,
  <ReferenceInput
    key={2}
    source="productCategoryId"
    label="Category"
    reference="product-categories"
  />,
];

const ProductList = () => {

  const theme = useTheme();
  const isSmall = useMediaQuery(theme.breakpoints.down("sm"));

  return (
    <List
      filters={productFilters}
    >
      {isSmall ? (
        <SimpleList
          primaryText={record => record.name}
          secondaryText={record => record.description}
          tertiaryText={record => record.price}
        />
      ) : (
        <Datagrid
          rowClick="edit"
          bulkActionButtons={false}
        >
          <TextField source="id" />
          <TextField source="name" />
          <TextField source="description" />
          <ReferenceField
            source="productCategoryId"
            reference="product-categories"
          />
          <NumberField
            source="price"
            options={{
              style: "currency",
              currency: "USD"
            }}
            textAlign="left"
          />
          <ImageField
            source="imageUri"
            sortable={false}
          />
        </Datagrid>
      )}
    </List>
  );
};

export default ProductList;
import { configureStore, combineReducers } from "@reduxjs/toolkit";
import {
  persistStore, persistReducer, FLUSH, REHYDRATE, PERSIST, PURGE, REGISTER, PAUSE 
} from "redux-persist";
import storage from "redux-persist/lib/storage";
import { apiSlice } from "./api/apiSlice";
import cartReducer from "./slices/cartSlice";

const persistConfig = {
  key: "root",
  storage,
  blacklist: ["api"]
};

const rootReducer = combineReducers({
  cart: cartReducer,
  [apiSlice.reducerPath]: apiSlice.reducer,
});

const persistedReducer = persistReducer(
  persistConfig,
  rootReducer
);

export const store = configureStore({
  reducer: persistedReducer,
  middleware: getDefaultMiddleware =>
    getDefaultMiddleware({
      serializableCheck: {
        ignoredActions: [FLUSH, REHYDRATE, PAUSE, PERSIST, PURGE, REGISTER],
      }
    }).concat(apiSlice.middleware)
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
import { configureStore } from "@reduxjs/toolkit";
import authReducer from "./auth/reducer";
import menuReducer from './menu/reducer'

export const store = configureStore({
    reducer: {
        authReducer,
        menuReducer,
    }
})
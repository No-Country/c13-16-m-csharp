import { createReducer } from "@reduxjs/toolkit";
import menuActions from './actions'

const {menuState} = menuActions

const initialState = {
    state: false
}

const menuReducer = createReducer(
    initialState,
    (builder) => builder
        .addCase(
            menuState,
            (state,action) => {
                let newState = {
                    ...state,
                    state: action.payload.state
                }
                return newState
            }
        )
)

export default menuReducer
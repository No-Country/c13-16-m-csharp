import { createReducer } from "@reduxjs/toolkit";
import authActions from './actions'

const {authState} = authActions

const initialState = {
    state: false
}

const authReducer = createReducer(
    initialState,
    (builder) => builder
        .addCase(
            authState,
            (state,action) => {
                let newState = {
                    ...state,
                    state: action.payload.state
                }
                return newState
            }
        )
)

export default authReducer
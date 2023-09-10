import { createAction } from "@reduxjs/toolkit";

let authState = createAction(
    'authState',
    ({state}) => {
        return {
            payload: {
                state: state
            }
        }
    }
)

const authActions = {authState}
export default authActions
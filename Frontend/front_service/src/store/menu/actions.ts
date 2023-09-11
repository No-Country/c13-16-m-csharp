import { createAction } from "@reduxjs/toolkit";

let menuState = createAction(
    'menuState',
    ({state}) => {
        return {
            payload: {
                state: state
            }
        }
    }
)

const menuActions = {menuState}
export default menuActions
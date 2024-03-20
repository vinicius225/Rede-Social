import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import AuthService from "../services/AuthService";

const user = JSON.parse(localStorage.getItem("user"));

const initialState = {
  user: user ? user : null,
  error: false,
  sucess: false,
  loading: false,
};

// register an user and sign in

export const register = createAsyncThunk(
  "auth/register",
  async (user, thunkAPI) => {
    const data = await AuthService.register(user);

    // check for errops
    if (data.erros) {
      return thunkAPI.rejectWithValue(data.erros[0]);
    }
  }
);
export const {reset} = authSlice.actions;
export default authSlice.reducer;
export const authSlice = createSlice({
  name: "auth",
  initialState,
  reducers: {
    reset: (statte) => {
      statte.loading = false;
      statte.error = false;
      statte.sucess = false;
    },
  },
  extraReducers: (builder) => {
    builder,
      addCase(register.pending, (state) => {
        state.loading = true;
        state.error = false;
      }).addCase(register.fulfilled, (state, actiod) => {
        state.loading = false;
        state.sucess = true;
        state.error = null;
        state.user = actiod.payload;
      }).addCase(register.rejected, (state, acstion)=>
      {
        state.loading = false;
        state.error = actiod.payload;
        state.user = null;
      });
  },
});

import { createSlice } from '@reduxjs/toolkit';

const initialState = {
    profile: {
        id: null,
        username: "",
        bio: "",
        avatar: ""
    },
    loading: false,
    error: null,
};

const profileSlice = createSlice({
    name: 'profile',
    initialState,
    reducers: {
        fetchProfileStart(state) {
            state.loading = true;
            state.error = null;
        },
        fetchProfileSuccess(state, action) {
            state.loading = false;
            state.profile = action.payload;
            state.error = null;
        },
        fetchProfileFailure(state, action) {
            state.loading = false;
            state.error = action.payload;
        },
        updateProfileStart(state) {
            state.loading = true;
            state.error = null;
        },
        updateProfileSuccess(state, action) {
            state.loading = false;
            state.profile = action.payload;
            state.error = null;
        },
        updateProfileFailure(state, action) {
            state.loading = false;
            state.error = action.payload;
        },
    },
});

export const {
    fetchProfileStart,
    fetchProfileSuccess,
    fetchProfileFailure,
    updateProfileStart,
    updateProfileSuccess,
    updateProfileFailure,
} = profileSlice.actions;

export default profileSlice.reducer;

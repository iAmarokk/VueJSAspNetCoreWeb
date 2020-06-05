import store from ".."

export default {
    actions: {},
    mutations: {},
    state: {
        post:[]
    },
    getters: {
        allPosts(state) {
            return state.posts
        }
    }
}
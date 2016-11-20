import querystring from 'querystring';

export const fetchGroup = ({ commit, state, dispatch, getters }, id) => {
    return new Promise((resolve, reject) => {
        getters.apiClient.get(`groups/${id}`, dispatch)
                             .then(response  => {
                                 commit("FETCH_GROUP", response.data);
                                 resolve();
                             }).catch( err => {
                                 console.log(err);
                             });    
    });
}

export const fetchGroups = ({ state, commit, dispatch, getters }) => {
    return new Promise((resolve, reject) => {
        getters.apiClient.get(`groups`, dispatch)
             .then(response  => {
                 commit("FETCH_GROUPS", response.data);
                 resolve()
             }).catch( err => {
                console.log(err);
                reject(err);
            });
    });
}


export const saveGroup = ({ commit, dispatch, getters }, newGroup) => {
    return new Promise((resolve, reject) => {
        getters.apiClient.post(`groups`, dispatch, { data: {	
            name: newGroup.name, 
            description: newGroup.description,
            mainImage: {
                caption: "",
                url: newGroup.image,
                createdBy: "be027871-85f3-4dcf-8466-a6922cfd7761"
            },
            state: 0,
            createdBy: "be027871-85f3-4dcf-8466-a6922cfd7761"
            // "mainImage": 23
        }})
        .then(response  => {
            commit("SAVE_GROUP", response.data);
            resolve();
        }).catch( err => {
            console.log(err);
        });
    });
}

export const deleteGroup = ({ commit, dispatch, getters }, group) => {
    return new Promise((resolve, reject) => {
        getters.apiClient.delete(`groups/${group.id}`, dispatch)
                    .then(response  => {
                        commit("DELETE_GROUP", group);
                        resolve();
                    }).catch( err => {
                        console.log(err);
                    });
    });
}


export const toggleNewGroupModal = ({commit}) => {
    commit("TOGGLE_NEW_GROUP_MODAL");
}

export const uploadImage = ({commit, dispatch, getters}, file) => {
    return new Promise((resolve, reject) => {

        const data = new FormData();
        data.append('prependDate', true);
        data.append('file', file);

        getters.apiClient.post('file', dispatch, { data }).then(response  => {
            resolve(response.data);
        }).catch( err => {
            console.log(err);
            reject(err);
        });
    });
}

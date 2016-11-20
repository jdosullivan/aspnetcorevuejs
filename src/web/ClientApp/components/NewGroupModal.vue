<template>
    <div>
        <modal id="modalNewGroup" @close="close">
            <div class="modal-header">
                <h3>Create Group</h3>
            </div>           
            <form id="frmNewGroup" @submit.prevent="saveAndclose">
                <div class="modal-body">
                    <div class="form-group row">
                        <input type="text" id="inputGroupName" class="form-control" placeholder="Name" v-model="name">
                    </div>
                    <div class="form-group row">
                        <textarea rows="4" class="form-control" id="inputGroupDescription" placeholder="Description" v-model="description"></textarea>
                    </div>
                    <div class="form-group row">
                        <ImageUpload id="groupCoverImage" :url="apiUrl + '/file'" :selectedImage="image" v-on:vdropzone-fileAdded="imageChanged" :thumbnailWidth="400" imagePlaceHolder="Click here to upload cover image"></ImageUpload>
                    </div>
                </div>
                <div class="modal-footer">
                    <slot name="footer">
                        <button slot="footer" type="submit" class="btn btn-primary modal-default-button">Create group</button>
                    </slot>
                </div>
            </form>            
        </modal>
    </div>
</template>

<script>    
    import modal from './Modal.vue'
    import ImageUpload from './ImageUpload.vue'
    import { mapActions, mapGetters } from 'vuex'
    
    export default {
        data: function() {
            return {
                name: '',
                description: '',
                image: ''
            }
        },
        computed: { 
            ...mapGetters(['apiUrl']),
            formData(){
                return {
                    name:this.name,
                    description: this.description,
                    image: this.image,
                    checked: this.checked,
                    picked: this.picked,
                    selected: this.selected,
                    multiSelect: this.multiSelect
                }
            }
        },
        components: { modal, ImageUpload }, 
        methods: { 
            ...mapActions(['saveGroup']),
            close() { 
                this.$emit('close');
            },
            saveAndclose() {
                this.saveGroup(this.formData).then(() => {
                    this.$emit('close');
                });
            },
            imageChanged(filedetails) {
                this.image = filedetails.filePath;
            }
        }
    }
</script>

<style>
    #modalNewGroup input {
        height: 60px;
    }
#modalNewGroup input, #modalNewGroup textarea {
    box-shadow: none;
    -webkit-box-shadow: none;
    margin: 0 auto;
    border: 1px solid #46529D;
    border-radius: 15px;
    display: block;
    box-shadow: none;
    -webkit-transition: all 0.3s;
    transition: all 0.3s;
}
   
 #modalNewGroup .modal-header {
    border: none;
    padding-bottom: 5px;
}
#modalNewGroup .modal-header h3 {
    color: #46529D;
    font-weight: 400;
    text-align: center;
    margin: 0;
    line-height: 1.42857143;
}

#modalNewGroup .modal-body {
    margin-top: 0;
}

#modalNewGroup .form-group {
    margin-bottom: 10px;
}

#modalNewGroup .modal-container {
    width: 500px;
    margin: 30px auto;
}
</style>
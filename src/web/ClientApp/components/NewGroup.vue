<template>
    <div>
        <div class="container">
            <form id="frmNewGroup"  @submit.prevent="saveGroup(formData)">
                <div class="form-group row">
                    <label for="inputGroupName" class="col-sm-2 col-form-label">Name</label>
                    <div class="col-sm-10">
                        <input type="text" id="inputGroupName" class="form-control"  placeholder="Name"  v-model="name">
                    </div>
                </div>
                <div class="form-group row">
                    <label for="inputGroupDescription" class="col-sm-2 col-form-label">Description</label>
                    <div class="col-sm-10">
                        <input type="text" class="form-control" id="inputGroupDescription" placeholder="Description"  v-model="description">
                    </div>
                </div>
                <div class="form-group row">
                    <label for="inputCoverImage" class="col-sm-2 col-form-label">Image</label>
                    <div class="col-sm-10">
                        <input type="text" class="form-control" id="inputCoverImage" placeholder="Cover image" v-model="image">
                    </div>
                </div>
                <div class="form-group row">
                    <div class="offset-sm-2 col-sm-10">
                        <!--<button type="submit" class="btn btn-primary">Create group</button>-->
                    </div>
                </div>
            </form>
        </div>
    </div>
</template>


<script>
    import { mapGetters, mapActions } from 'vuex'

    export default {
      data: function() {
        return {
            name: 'hi!',
            description: '',
            image: '',
            checked: true,
            picked: 'one',
            selected: 'two',
            multiSelect: ['one', 'three']
        }
      },
      computed:{
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
      methods: mapActions(['saveGroup']) 
   }
</script>
<template>
    <div>
        <form :id="id" :action="url" class="dropzone"></form>
    </div>
</template>


<script>
    import { mapGetters, mapActions } from 'vuex'
    const isBrowser = typeof window !== 'undefined';
    const Dropzone = isBrowser ? require( 'dropzone') : undefined;
    
    export default {
        mounted() { 
            var element = document.getElementById(this.id);
         
            if (!this.useCustomDropzoneOptions) {
                this.dropzone = new Dropzone(element, {
                    clickable: this.clickable,
                    thumbnailWidth: this.thumbnailWidth,
                    thumbnailHeight: this.thumbnailHeight,
                    maxFiles: this.maxNumberOfFiles,
                    maxFilesize: this.maxFileSizeInMB,
                    dictRemoveFile: 'Remove',
                    addRemoveLinks: this.showRemoveLink,
                    acceptedFiles: this.acceptedFileTypes,
                    autoProcessQueue: this.autoProcessQueue,
                    dictDefaultMessage: this.imagePlaceHolder,
                    previewTemplate: '<div class="dz-preview dz-file-preview">  <div class="dz-image" style="width:' + this.thumbnailWidth + 'px;height:' + this.thumbnailHeight + 'px"><img data-dz-thumbnail /></div>  <div class="dz-details"> <div class="dz-error-message"><span data-dz-errormessage></span></div>  <div class="dz-success-mark"> <i class="material-icons">done</i> </div>  <div class="dz-error-mark"><i class="material-icons">error</i></div></div>'
                })
            } else {
                this.dropzone = new Dropzone(element, this.dropzoneOptions)
            }

            // Handle the dropzone events
            var vm = this
            this.dropzone.on('addedfile', (file) => {
                vm.uploadImage(file).then((response) => {
                    vm.$emit('vdropzone-fileAdded', response);  
                });
            })

            this.dropzone.on('removedfile', function (file) {
                vm.$emit('vdropzone-removedFile', file);
            })

            this.dropzone.on('success', function (file, response) {
                vm.$emit('vdropzone-success', file, response);
            })

            this.dropzone.on('error', function (file, error, xhr) {
                vm.$emit('vdropzone-error', file, error, xhr);
            })
        },
    props: {
            id: {
                type: String,
                required: true
            },
            url: {
                    type: String,
                    required: true
            },
            imagePlaceHolder: {
                type: String,
                default: "Drop files here to upload"
            },
            selectedImage: {
                type: String
            },
            clickable: {
                    type: Boolean,
                    default: true
            },
            acceptedFileTypes: {
                type: String
            },
            thumbnailHeight: {
                    type: Number,
                    default: 200
            },
            thumbnailWidth: {
                    type: Number,
                    default: 300
            },
            showRemoveLink: {
                    type: Boolean,
                    default: true
            },
            maxFileSizeInMB: {
                type: Number,
                default: 2
            },
            maxNumberOfFiles: {
                    type: Number,
                    default: 5
            },
            autoProcessQueue: {
                    type: Boolean,
                    default: false
            },
            useCustomDropzoneOptions: {
                    type: Boolean,
                    default: false
            },
            dropzoneOptions: {
                    type: Object
            }
    },
    events: {
            removeAllFiles: function () {
                this.dropzone.removeAllFiles(true)
            },
            processQueue: function () {
                this.dropzone.processQueue()
            }
    },
    methods: { 
        ...mapActions(['uploadImage'])
    },
}
</script>


<style>
    @import url('../../node_modules/dropzone/dist/dropzone.css');
    @import 'https://fonts.googleapis.com/css?family=Roboto';

    html {
        background-color: #F9F9F9;
    }

    .dropzone {
        border: 1px solid #46529D;
        color: #777;
        transition: background-color .2s linear;
        padding: 10px 10px;
    }

        .dropzone:hover {
            background-color: #F6F6F6;
        }


    i {
        color: #CCC;
    }

    .dropzone .dz-preview {
        margin: 0;
    }

    .dropzone .dz-preview .dz-image {
        border-radius: 0px;
    }

    .dropzone .dz-preview:hover .dz-image img {
        transform: none;
        -webkit-filter: none;
    }

    .dropzone .dz-preview .dz-details {
        bottom: 0px;
        top: 0px;
        color: white;
        background-color: rgba(33, 150, 243, 0.8);
        transition: opacity .2s linear;
        text-align: left;
    }

        .dropzone .dz-preview .dz-details .dz-filename span, .dropzone .dz-preview .dz-details .dz-size span {
            background-color: transparent;
        }

        .dropzone .dz-preview .dz-details .dz-filename:not(:hover) span {
            border: none;
        }

        .dropzone .dz-preview .dz-details .dz-filename:hover span {
            background-color: transparent;
            border: none;
        }

    .dropzone .dz-preview .dz-remove {
        position: absolute;
        z-index: 30;
        color: white;
        margin-left: 15px;
        padding: 10px;
        top: inherit;
        bottom: 15px;
        border: 2px white solid;
        text-decoration: none;
        text-transform: uppercase;
        font-size: 0.8rem;
        font-weight: 800;
        letter-spacing: 1.1px;
        opacity: 0;
    }

    .dropzone .dz-preview:hover .dz-remove {
        opacity: 1;
    }

    .dropzone .dz-preview .dz-success-mark, .dropzone .dz-preview .dz-error-mark {
        margin-left: -40px;
        margin-top: -50px;
    }

    .dropzone .dz-preview .dz-success-mark i, .dropzone .dz-preview .dz-error-mark i {
        color: white;
        font-size: 5rem;
    }
</style>
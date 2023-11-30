import { Button, FormControl, FormLabel, Input, Modal, ModalBody, ModalCloseButton, ModalContent, ModalFooter, ModalHeader, ModalOverlay, Select, Textarea } from '@chakra-ui/react'
import React, { useEffect, useState } from 'react'

export const RecipeNewEdit = (
  props: {
    isOpen: boolean,
    onClose: () => void,
    recipeId?: string,
    onUpdate:()=>void
  }
) => {
  const [form, setForm] = useState<{ title: string, category: string, description: string }>({ title: '', category: '', description: '' })
  const [categories, setCategories] = useState<{ id: string, name: string }[]>([])

  useEffect(()=>{
    async function getCategories() {
      try {
        const response = await fetch(`http://localhost:5000/api/categories`, {
          method: 'GET',
        });
        const data = await response.json();
        const dataCat:{id:string,name:string}[] = []
        data.forEach((e:any) => {
          dataCat.push({id:e.id,name:e.name})
        });
        setCategories(dataCat)
      } catch (Exeption) {

      }
    }
    getCategories()
  },[])

  useEffect(() => {
    async function getRecipe(recipe: string) {
      try {
        const response = await fetch(`http://localhost:5000/api/recipes/${recipe}`, {
          method: 'GET',
        });
        const data = await response.json()
        setForm({
          ...form,
          title: data.title.value,
          category: data.categoryId,
          description: data.description.value
        })
      } catch (Exeption) {

      }
    }
    if (props.recipeId) {
      getRecipe(props.recipeId)
    }
  }, [props.recipeId])

  function handleSubmit(e: React.FormEvent<HTMLFormElement>) {
    e.preventDefault()
    const data = {
      title: form.title,
      categoryId: form.category,
      description: form.description
    }
    if (props.recipeId) {
      updateRecipe(props.recipeId, data)
    } else {
      createRecipe(data)
    }
    handleClose() 
    props.onUpdate()
  }

  function handleChange(e: React.ChangeEvent<HTMLInputElement|HTMLTextAreaElement|HTMLSelectElement >) {
    setForm({
      ...form,
      [e.target.name]: e.target.value
    })
  }

  async function createRecipe(data: any): Promise<void> {
    try {
      console.log(data)
      const response = await fetch("http://localhost:5000/api/recipes", {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
          // 'Content-Type': 'application/x-www-form-urlencoded',
        },
        body: JSON.stringify(data) // body data type must match "Content-Type" header
      });
      response.json(); // parses JSON response into native JavaScript objects
    } catch (Exeption) {

    }
  }

  async function updateRecipe(recipeId: string, data: any) {
    try {
      const response = await fetch(`http://localhost:5000/api/recipes/${recipeId}`, {
        method: 'PATCH',
        headers: {
          'Content-Type': 'application/json'
          // 'Content-Type': 'application/x-www-form-urlencoded',
        },
        body: JSON.stringify(data) // body data type must match "Content-Type" header
      });
      await response.json();
    } catch (Exeption) {
    }

  }

  function handleClose()
  {
    props.onClose()
    setForm({title:'',category:'',description:''})
  }

  return (
    <Modal isOpen={props.isOpen} onClose={handleClose}>
      <ModalOverlay />
      <ModalContent>
        <ModalHeader>
          {props.recipeId ?
            "Editar Receta"
            :
            "Nueva Receta"
          }
        </ModalHeader>
        <ModalCloseButton />
        <ModalBody>
          <FormControl
          >
            <form
              id='new-recipe'
              onSubmit={(e) => handleSubmit(e)}
            >
              <FormLabel>Titulo</FormLabel>
              <Input
                name="title"
                type='text'
                defaultValue={form.title}
                onChange={(e) => handleChange(e)}
              />
              <FormLabel>Categoria</FormLabel>
              <Select placeholder='Categoria' name='category' onChange={(e)=>handleChange(e)}>
                {

                  categories.map((e,idx)=>{
                   return <option key={idx} value={e.id}>{e.name}</option>

                  })
                }
              </Select>
              <FormLabel>Descripcion</FormLabel>
              <Textarea 
                name='description'
                onChange={(e)=>handleChange(e)}
                placeholder='Descripcion'
                defaultValue={form.description}
              />
            </form>
          </FormControl>
        </ModalBody>
        <ModalFooter>
          <Button
            form='new-recipe'
            type='submit'
            py='5px'
            colorScheme='green'>
            {props.recipeId ?
              "Editar"
              :
              "Crear"
            }
          </Button>
        </ModalFooter>
      </ModalContent>
    </Modal>
  )
}


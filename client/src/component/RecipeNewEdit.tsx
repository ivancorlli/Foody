import { Button, FormControl, FormLabel, Input, Modal, ModalBody, ModalCloseButton, ModalContent, ModalFooter, ModalHeader, ModalOverlay } from '@chakra-ui/react'
import React, { useEffect, useState } from 'react'

export const RecipeNewEdit = (
  props: {
    isOpen: boolean,
    onClose: () => void,
    recipeId?: string
  }
) => {
  const [form, setForm] = useState<{ title: string, category: string, description: string }>({ name: '', category: '', description: '' })

  useEffect(() => {
    async function getCategory(recipe: string) {
      try {
        const response = await fetch(`http://localhost:5000/api/recipes/${recipe}`, {
          method: 'GET',
          mode: 'no-cors',
          credentials: 'omit',
          headers: {
            'Content-Type': 'application/json'
          }
        });
        response.json(); // parses JSON response into native JavaScript objects
      } catch (Exeption) {

      }
    }
    if (props.recipeId) {
      getCategory(props.recipeId)
    }
  }, [props.recipeId])

  function handleSubmit(e: React.FormEvent<HTMLFormElement>) {
    e.preventDefault()
    const data = {
      Title: form.title,
      CategoryId: form.category,
      Description: form.description
    }
    if (props.recipeId) {
      updateRecipe(props.recipeId, data)
    } else {
      createRecipe(data)
    }
  }

  function handleChange(e: React.ChangeEvent<HTMLInputElement>) {
    setForm({
      ...form,
      [e.target.value]: e.target.value
    })
  }

  async function createRecipe(data: any): Promise<void> {
    try {
      const response = await fetch("http://localhost:5000/api/recipes", {
        method: 'POST',
        mode: 'no-cors',
        credentials: 'omit',
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
        mode: 'no-cors',
        credentials: 'omit',
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

  return (
    <Modal isOpen={props.isOpen} onClose={props.onClose}>
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


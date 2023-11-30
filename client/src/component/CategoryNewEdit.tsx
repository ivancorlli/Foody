import { Button, FormControl, FormLabel, Input, Modal, ModalBody, ModalCloseButton, ModalContent, ModalFooter, ModalHeader, ModalOverlay } from '@chakra-ui/react'
import React, { useEffect, useState } from 'react'

export const CategoryNewEdit = (
  props: {
    isOpen: boolean,
    onClose: () => void,
    categoryId?: string
  }
) => {
  const [form, setForm] = useState<{ name: string }>({ name: '' })

  useEffect(() => {
    async function getCategory(categoryId: string) {
      try {
        const response = await fetch(`http://localhost:5000/api/categories/${categoryId}`, {
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
    if (props.categoryId) {
      getCategory(props.categoryId)
    }
  }, [props.categoryId])

  function handleSubmit(e: React.FormEvent<HTMLFormElement>) {
    e.preventDefault()
    const data = {
      Name: form.name
    }
    if (props.categoryId) {
      updateCategory(props.categoryId, data)
    } else {
      createCategory(data)
    }
  }

  function handleChange(e: React.ChangeEvent<HTMLInputElement>) {
    setForm({
      name: e.target.value
    })
  }

  async function createCategory(data: any): Promise<void> {
    try {
      const response = await fetch("http://localhost:5000/api/categories", {
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

  async function updateCategory(categoryId: string, data: any) {
    try {
      const response = await fetch(`http://localhost:5000/api/categories/${categoryId}`, {
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
          {props.categoryId ?
            "Editar Categoria"
            :
            "Nueva Categoria"
          }
        </ModalHeader>
        <ModalCloseButton />
        <ModalBody>
          <FormControl
          >
            <form
              id='new-category'
              onSubmit={(e) => handleSubmit(e)}
            >
              <FormLabel>Nombre</FormLabel>
              <Input
                name="name"
                type='text'
                defaultValue={form.name}
                onChange={(e) => handleChange(e)}
              />
            </form>
          </FormControl>
        </ModalBody>
        <ModalFooter>
          <Button
            form='new-category'
            type='submit'
            py='5px'
            colorScheme='green'>
            {props.categoryId ?
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

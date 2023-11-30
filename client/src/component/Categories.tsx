import React, { useEffect, useState } from 'react'
import { HStack, VStack, Button, Heading, useDisclosure, Stack, Skeleton, isChakraTheme, Divider } from '@chakra-ui/react'
import { CategoryNewEdit } from './CategoryNewEdit'
import { Category } from './Category'

interface ICategory {
  id: string,
  name: string
}

export const Categories = () => {
  const { isOpen, onOpen, onClose } = useDisclosure()
  const [categories, setCategories] = useState<ICategory[]>([])
  const [selected, setSelected] = useState<string| undefined>();
  function handleSelect(categoryId: string) {
    setSelected(categoryId)
    onOpen()
  }

  useEffect(()=>{
    async function getRecipes()
    {
      try {
        const response = await fetch(`http://localhost:5000/api/categories`, {
          method: 'GET'
        });
        const data = await response.json();
        const lrecipes:ICategory[]=[]
        data.forEach((e:any) => {
          const ex:ICategory={
            id:e.id,
            name:e.name,
          }
          lrecipes.push(ex)
        });
        setCategories(lrecipes)
      } catch (Exeption ) {
        console.log(Exeption)
      }
    }
    getRecipes()
  },[categories])

  async function onUpdate() {
    try {
      const response = await fetch(`http://localhost:5000/api/categories`, {
        method: 'GET'
      });
      const data = await response.json();
      const lrecipes:ICategory[]=[]
      data.forEach((e:any) => {
        const ex:ICategory={
          id:e.id,
          name:e.name,
        }
        lrecipes.push(ex)
      });
      setCategories(lrecipes)
      setSelected(undefined)
    } catch (Exeption ) {
      console.log(Exeption)
    } 
  }

  function handleClose()
  {
    onClose()
    setSelected(undefined) 
  }

  return (
    <VStack
      w="50%"
      h="100%"
      spacing={5}
    >
      <HStack
        align="center"
        spacing={5}
        justifyContent='space-between'
        w='100%'
      >
        <Heading as='h6' size='md' >Listado de categorias</Heading>
        <Button
          py='5px'
          onClick={() => onOpen()}
          colorScheme='blue'>
          Nueva
        </Button>
      </HStack>
      <Divider />
      <CategoryNewEdit
        isOpen={isOpen}
        onClose={handleClose}
        categoryId={selected}
        onUpdate={onUpdate}
      />
      {
        categories.length > 0 ?
          categories.map((e, idx) => {
            return <Category
              key={idx}
              categoryId={e.id}
              name={e.name}
              idx={idx + 1}
              select={handleSelect}
            />
          })
          :
          <>
            <Stack h="100%" w="100%">
              <Skeleton height='40px' />
              <Skeleton height='40px' />
              <Skeleton height='40px' />
            </Stack>
          </>
      }
    </VStack>
  )
}


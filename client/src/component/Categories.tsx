import React, { useState } from 'react'
import { HStack, VStack, Button, Heading, useDisclosure, Stack, Skeleton, isChakraTheme, Divider } from '@chakra-ui/react'
import { CategoryNewEdit } from './CategoryNewEdit'
import { Category } from './Category'

interface ICategory {
  id: string,
  name: string
}

export const Categories = () => {
  const { isOpen, onOpen, onClose } = useDisclosure()
  const [categories, setCategories] = useState<ICategory[]>([{ id: "09800dfhjk-123", name: "ejemplo" }])
  const [selected, setSelected] = useState<string>();
  function handleSelect(categoryId: string) {
    setSelected(categoryId)
    onOpen()
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
        onClose={onClose}
        categoryId={selected}
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

